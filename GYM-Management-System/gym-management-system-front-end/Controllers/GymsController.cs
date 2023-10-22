using gym_management_system_front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace gym_management_system_front_end.Controllers
{
    public class GymsController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7200/api/Gyms");
        private readonly HttpClient _client;

        public GymsController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public async Task<IActionResult> Index()
        {
            List<GymViewModel> gymList = new List<GymViewModel>();

            var response = await _client.GetAsync(_client.BaseAddress + "/GetGymsBackEnd");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                gymList = JsonConvert.DeserializeObject<List<GymViewModel>>(data);
            }
            return View(gymList);
        }

        public async Task<IActionResult> ClientIndex()
        {
            List<GymViewModel> gymList = new List<GymViewModel>();

            var response = await _client.GetAsync(_client.BaseAddress + "/GetGymsBackEnd");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                gymList = JsonConvert.DeserializeObject<List<GymViewModel>>(data);
            }
            return View(gymList);
        }

        public IActionResult Manager()
        {
            List<GetManagerGymDTO> gymList = new List<GetManagerGymDTO>();
            var response = _client.GetAsync(_client.BaseAddress + "/GetGymManagerBackEnd").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                gymList = JsonConvert.DeserializeObject<List<GetManagerGymDTO>>(data);
            }
            return View(gymList);
        }

        public async Task<ActionResult<GymViewModel>> Details(int id)
        {
            var gymViewModel = new GymViewModel();
            var response = await _client.GetAsync(_client.BaseAddress + "/GetGymBackEnd/" + id);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                gymViewModel = JsonConvert.DeserializeObject<GymViewModel>(data);
            }
            return View(gymViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var actionResult = await Details(id);
            if (actionResult.Result is ViewResult viewResult)
            {
                var gym = viewResult.Model as GymViewModel;
                if (gym == null)
                {
                    return NotFound();
                }
                return View(gym);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int GymID)
        {
            var actionResult = await Details(GymID);
            if (actionResult.Result is ViewResult viewResult)
            {
                var gym = viewResult.Model as GymViewModel;
                if (gym == null)
                {
                    return NotFound();
                }
                var response = await _client.DeleteAsync(_client.BaseAddress + "/DeleteGymBackEnd/" + GymID);

                if (response.IsSuccessStatusCode)
                {
                    // Handle successful delete here
                }
                return RedirectToAction("Index", "Gyms");
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actionResult = await Details(id);
            if (actionResult.Result is ViewResult viewResult)
            {
                var gym = viewResult.Model as GymViewModel;

                if (gym == null)
                {
                    return NotFound();
                }

                return View((PutGymDTO)gym);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PutGymDTO gymDTO, IFormFile file)
        {
            if (file != null)
            {
                var streamcontent = new StreamContent(file.OpenReadStream());

                streamcontent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

                var imageContent = new MultipartFormDataContent
                {
                    { streamcontent, "file", file.FileName }
                };
                var imageResponse = await _client.PostAsync(_client.BaseAddress + "/Methods/AddImageToCloudBackEnd", imageContent);
                gymDTO.imageURL = await imageResponse.Content.ReadAsStringAsync();
            }

            var json = JsonConvert.SerializeObject(gymDTO);

            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(_client.BaseAddress + "/PutGymBackEnd/" + gymDTO.GymID, stringContent);

            if (response.IsSuccessStatusCode)
            {
                // Handle successful delete here
            }
            return RedirectToAction("Index", "Gyms");

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostGymDTO gym, IFormFile file)
        {

            if (file != null)
            {
                var streamcontent = new StreamContent(file.OpenReadStream());

                streamcontent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

                var imageContent = new MultipartFormDataContent
     {
         { streamcontent, "file", file.FileName }
                };
                var imageResponse = await _client.PostAsync("https://localhost:7200/api/Methods/AddImageToCloud", imageContent);
                gym.imageURL = await imageResponse.Content.ReadAsStringAsync();
            }

            var jsonContent = new StringContent(JsonConvert.SerializeObject(gym), Encoding.UTF8, "application/json");

            string jwtToken = Request.Cookies["JWTToken"];

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            var response = await _client.PostAsync(_client.BaseAddress + "/PostGymBackEnd", jsonContent);
            var data = await response.Content.ReadAsStringAsync();
            gym = JsonConvert.DeserializeObject<PostGymDTO>(data);
            return RedirectToAction("Index", "Gyms");
        }

        [HttpGet]
        public async Task<IActionResult> AddSupplementToGym(int gymid)
        {
            var gymResponse = await _client.GetAsync($"https://localhost:7200/api/Gyms/GetGymBackEnd/{gymid}");
            var gymResult = await gymResponse.Content.ReadAsStringAsync();
            var gymList = JsonConvert.DeserializeObject<GetUserGymDTO>(gymResult);

            var idList = new GymIDDTO() 
            {
               
                GymID = gymList.GymID,
                Name=gymList.Name

            };
           

            var supplementResponse = await _client.GetAsync("https://localhost:7200/api/Supplements/GetSupplementsBackEnd");
            var supplementResult = await supplementResponse.Content.ReadAsStringAsync();
            var supplementList = JsonConvert.DeserializeObject<List<SupplementIDDTO>>(supplementResult);

            var list = new List<GymSupplementDTO>();

            foreach (var item in supplementList)
            {
                // Check if the SupplementID is already in gymList.Supplements
                if (!gymList.Supplements.Any(s => s.SupplementID == item.SupplementID))
                {
                    list.Add(new GymSupplementDTO
                    {
                        SupplementID = item.SupplementID,
                        Name = item.Name // Assuming 'Name' is the property in SupplementIDDTO
                    });
                }
            }

            var supplementIDList = list.Select(s => new SupplementIDDTO
            {
                SupplementID = s.SupplementID,
                Name = s.Name // Include the 'Name' property
            }).ToList();

            var returnClientView = new GymSupplementViewModel
            {
                GymIDs =idList ,
                GymID = idList.GymID,
                SupplementIDs = supplementIDList,
            };

            return View(returnClientView);
        }

        [HttpPost]
        public IActionResult AddSupplementToGym(GymSupplementViewModel newGymSupplement)
        {
            var supplementResponse = _client.GetAsync("https://localhost:7200/api/Supplements/GetSupplementBackEnd/" + newGymSupplement.SupplementID).Result;

            if (supplementResponse.IsSuccessStatusCode)
            {
                string supplementData = supplementResponse.Content.ReadAsStringAsync().Result;
                newGymSupplement.Supplement = JsonConvert.DeserializeObject<SupplementViewModel>(supplementData);

                var jsonContent = new StringContent(JsonConvert.SerializeObject(newGymSupplement), Encoding.UTF8, "application/json");
                var response = _client.PostAsync(_client.BaseAddress + "/AddSupplementsToGymBackEnd/" + newGymSupplement.GymID + "/Supplement/" + newGymSupplement.SupplementID, jsonContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "Supplement Created successfully";
                }
                else
                {
                    TempData["error"] = "Add Process failed";
                }
            }
            else
            {
                ModelState.AddModelError("", "Failed to retrieve supplement details. Please try again.");
                TempData["error"] = "Add Process failed";
                return View(newGymSupplement);
            }

            return RedirectToAction("Details", "Gyms", new { id = newGymSupplement.GymID });

        }

        [HttpGet]
        public IActionResult UpdateSupplementForGym(int gymId, int supplementId, int quantity)
        {
            var gymSupplement = new GymSupplementViewModel
            {
                GymID = gymId,
                SupplementID = supplementId,
                Quantity = quantity
            };

            // Make a call to your API to get supplement info
            var supplementResponse = _client.GetAsync("https://localhost:7200/api/Supplements/GetSupplementBackEnd/" + supplementId).Result;

            if (supplementResponse.IsSuccessStatusCode)
            {
                string supplementData = supplementResponse.Content.ReadAsStringAsync().Result;
                gymSupplement.Supplement = JsonConvert.DeserializeObject<SupplementViewModel>(supplementData);
            }
            else
            {
                TempData["error"] = "Update Process failed";
            }

            return View(gymSupplement);
        }

        [HttpPost]
        public IActionResult ConfirmUpdateSupplementForGym(GymSupplementViewModel updatedGymSupplement)
        {
            var supplementResponse = _client.GetAsync("https://localhost:7200/api/Supplements/GetSupplementBackEnd/" + updatedGymSupplement.SupplementID).Result;

            if (supplementResponse.IsSuccessStatusCode)
            {
                string supplementData = supplementResponse.Content.ReadAsStringAsync().Result;
                updatedGymSupplement.Supplement = JsonConvert.DeserializeObject<SupplementViewModel>(supplementData);

                var jsonContent = new StringContent(JsonConvert.SerializeObject((UpdateGymSupplementDTO)updatedGymSupplement), Encoding.UTF8, "application/json");
                var response = _client.PutAsync(_client.BaseAddress + "/UpdateSupplementForGymBackEnd/" + updatedGymSupplement.GymID + "/Supplement/" + updatedGymSupplement.SupplementID, jsonContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "Supplement Updated successfully";
                }
                else
                {
                    TempData["error"] = "Update Process failed";
                }
            }
            else
            {
                ModelState.AddModelError("", "Failed to retrieve supplement details. Please try again.");
                TempData["error"] = "Update Process failed";
            }


            return RedirectToAction("Index", "Gyms");
        }



        [HttpGet]
        public IActionResult RemoveSupplementFromGym(int gymId, int supplementId)
        {
            var gymSupplement = new GymSupplementViewModel
            {
                GymID = gymId,
                SupplementID = supplementId
            };

            // Make a call to your API to get supplement info
            var supplementResponse = _client.GetAsync("https://localhost:7200/api/Supplements/GetSupplementBackEnd/" + supplementId).Result;

            if (supplementResponse.IsSuccessStatusCode)
            {
                string supplementData = supplementResponse.Content.ReadAsStringAsync().Result;
                gymSupplement.Supplement = JsonConvert.DeserializeObject<SupplementViewModel>(supplementData);
            }
            else
            {
                TempData["error"] = "Update Process failed";
            }

            return View(gymSupplement);
        }



        [HttpPost]
        public IActionResult ConfirmRemoveSupplementFromGym(GymSupplementViewModel updatedGymSupplement)
        {
            var response = _client.DeleteAsync(_client.BaseAddress + "/RemoveSupplementFromGymBackEnd/" + updatedGymSupplement.GymID + "/Supplement/" + updatedGymSupplement.SupplementID).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Supplement removed successfully";
            }
            else
            {
                TempData["error"] = "Failed to remove supplement. Please try again.";
            }

            return RedirectToAction("Index", "Gyms");
        }


    }
}