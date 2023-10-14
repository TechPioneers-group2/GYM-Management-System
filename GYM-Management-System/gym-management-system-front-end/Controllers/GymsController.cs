using gym_management_system_front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public IActionResult Index()
        {
            List<GymViewModel> gymList = new List<GymViewModel>();
            var response = _client.GetAsync(_client.BaseAddress + "/GetGyms").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                gymList = JsonConvert.DeserializeObject<List<GymViewModel>>(data);
            }
            return View(gymList);
        }

        public async Task<ActionResult<GymViewModel>> Details(int id)
        {
            var gymViewModel = new GymViewModel();
            var response = await _client.GetAsync(_client.BaseAddress + "/GetGym/" + id);

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
                var response = await _client.DeleteAsync(_client.BaseAddress + "/DeleteGym/" + GymID);

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
        public async Task<IActionResult> Edit(PutGymDTO gymDTO)
        {

            var json = JsonConvert.SerializeObject(gymDTO);

            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(_client.BaseAddress + "/PutGym/" + gymDTO.GymID, stringContent);

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
        public IActionResult Create(PostGymDTO gym)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(gym), Encoding.UTF8, "application/json");
            var response = _client.PostAsync(_client.BaseAddress + "/PostGym", jsonContent).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            gym = JsonConvert.DeserializeObject<PostGymDTO>(data);
            return RedirectToAction("Index", "Gyms");
        }
    }
}