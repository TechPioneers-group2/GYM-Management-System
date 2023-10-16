using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace gym_management_system_front_end.Controllers
{
    public class EquipmentController : Controller
    {
        Uri BaseAdress = new Uri("https://localhost:7200/api");
        private readonly HttpClient _httpClient;
        

        public EquipmentController( )
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = BaseAdress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<EquipmentViewModel> equipments = new List<EquipmentViewModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/GymEquipments/Get").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                equipments = JsonConvert.DeserializeObject<List<EquipmentViewModel>>(data);


            }
            return View(equipments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(EquipmentViewModel equipment, IFormFile file)

        {
            using(var content = new MultipartFormDataContent())
            {
                
                    // Serialize the equipment object to JSON
                    var equipmentJson = JsonConvert.SerializeObject(equipment);

                    // Create a StringContent object with JSON data
                     content.Add(new StringContent(equipmentJson, Encoding.UTF8, "application/json"));

                if (file != null)
                {
                    var streamcontent = new StreamContent(file.OpenReadStream());
                    streamcontent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                    content.Add(streamcontent, "file" ,file.FileName) ;
                }

                    // Send a POST request to the API to create a new equipment
                    var response = _httpClient.PostAsync(_httpClient.BaseAddress + "/GymEquipments/PostGymEquipment", content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        // Equipment created successfully, you can redirect to the equipment list or a success page.
                        return RedirectToAction("Index", "Equipment");
                    }
                    else
                    {
                        // Handle the case where creating the equipment was not successful.
                        throw new Exception(response.StatusCode.ToString());
                    }
             }
            


            return View(equipment);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            EquipmentViewModel equipment = new EquipmentViewModel();
            HttpResponseMessage response = _httpClient.GetAsync($"{_httpClient.BaseAddress}/GymEquipments/GetGymEquipment/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                equipment = JsonConvert.DeserializeObject<EquipmentViewModel>(data);


            }
            return View(equipment);
        }
        [HttpPost]
        public IActionResult Edit(int id, EquipmentViewModel equipment)
        {
            if (ModelState.IsValid)
            {
                // Serialize the equipment object to JSON
                var equipmentJson = JsonConvert.SerializeObject(equipment);

                // Create a StringContent object with JSON data
                var content = new StringContent(equipmentJson, Encoding.UTF8, "application/json");

                // Send a POST request to the API to create a new equipment
                var response = _httpClient.PutAsync($"{_httpClient.BaseAddress}/GymEquipments/PutGymEquipment/{id}", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    // Equipment created successfully, you can redirect to the equipment list or a success page.
                    return RedirectToAction("Index");
                }
                else
                {
                    // Handle the case where creating the equipment was not successful.
                    ModelState.AddModelError(string.Empty, "Error Editing equipment.");
                }
            }
            return View(equipment);
        }
        [HttpGet]
        [ActionName("Delete")]
        public IActionResult DeleteGet(int id)
        {
            EquipmentViewModel equipment = new EquipmentViewModel();
            HttpResponseMessage response = _httpClient.GetAsync($"{_httpClient.BaseAddress}/GymEquipments/GetGymEquipment/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                equipment = JsonConvert.DeserializeObject<EquipmentViewModel>(data);


            }
            return View(equipment);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {

                var response = _httpClient.DeleteAsync($"{_httpClient.BaseAddress}/GymEquipments/DeleteGymEquipment/{id}").Result;

                if (response.IsSuccessStatusCode)
                {
                    // Equipment created successfully, you can redirect to the equipment list or a success page.
                    return RedirectToAction("Index");
                }
                else
                {
                    // Handle the case where creating the equipment was not successful.
                    ModelState.AddModelError(string.Empty, "Error Deleting equipment.");
                }
            }
            return View(Index);
        }
    }
}
