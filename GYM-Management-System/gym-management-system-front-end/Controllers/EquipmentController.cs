﻿using gym_management_system_front_end.Models;
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


        public EquipmentController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = BaseAdress;
        }

        [HttpGet]
        public IActionResult TableView()
        {
            List<EquipmentViewModel> equipments = new List<EquipmentViewModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/GymEquipments/GetBackEnd").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                equipments = JsonConvert.DeserializeObject<List<EquipmentViewModel>>(data);
            }
            return View(equipments);
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<EquipmentViewModel> equipments = new List<EquipmentViewModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/GymEquipments/GetBackEnd").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                equipments = JsonConvert.DeserializeObject<List<EquipmentViewModel>>(data);

            }

            return View(equipments);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var gymResponse = await _httpClient.GetAsync("https://localhost:7200/api/Gyms/GetGymsBackEnd");
            var gymResult = await gymResponse.Content.ReadAsStringAsync();
            var gymList = JsonConvert.DeserializeObject<List<GetUserGymDTO>>(gymResult);

            var idList = new List<GymIDDTO>();

            foreach (var item in gymList)
            {
                idList.Add(new GymIDDTO
                {
                    GymID = item.GymID,
                    Name = item.Name,
                });
            }

            var returnClientView = new EquipmentViewModel
            {
                GymIDsNames = idList,
            };

            return View(returnClientView);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(EquipmentViewModel equipment, IFormFile file)
        {
            if (file != null)
            {
                var streamcontent = new StreamContent(file.OpenReadStream());

                streamcontent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

                var imageContent = new MultipartFormDataContent
                {
                    { streamcontent, "file", file.FileName }
                };

                var imageResponse = await _httpClient.PostAsync(_httpClient.BaseAddress + "/Methods/AddImageToCloudBackEnd", imageContent);

                equipment.PhotoUrl = await imageResponse.Content.ReadAsStringAsync();
            }

            var equipmentJson = JsonConvert.SerializeObject(equipment);

            var jsonContent = (new StringContent(equipmentJson, Encoding.UTF8, "application/json"));

            var jsonResponse = _httpClient.PostAsync(_httpClient.BaseAddress + "/GymEquipments/PostGymEquipmentBackEnd", jsonContent).Result;

            if (jsonResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Equipment");
            }

            else
            {
                throw new Exception(jsonResponse.StatusCode.ToString());
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            EquipmentViewModel equipment = new EquipmentViewModel();
            HttpResponseMessage response = _httpClient.GetAsync($"{_httpClient.BaseAddress}/GymEquipments/GetGymEquipmentBackEnd/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                equipment = JsonConvert.DeserializeObject<EquipmentViewModel>(data);
            }

            return View(equipment);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EquipmentViewModel equipment, IFormFile file)
        {

            if (file != null)
            {
                var streamcontent = new StreamContent(file.OpenReadStream());

                streamcontent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

                var imageContent = new MultipartFormDataContent
                {
                    { streamcontent, "file", file.FileName }
                };

                var imageResponse = await _httpClient.PostAsync(_httpClient.BaseAddress + "/Methods/AddImageToCloudBackEnd", imageContent);

                equipment.PhotoUrl = await imageResponse.Content.ReadAsStringAsync();
            }

            // Serialize the equipment object to JSON
            var equipmentJson = JsonConvert.SerializeObject(equipment);

            // Create a StringContent object with JSON data
            var jsonContent = new StringContent(equipmentJson, Encoding.UTF8, "application/json");

            // Send a POST request to the API to create a new equipment
            var jsonResponse = _httpClient.PutAsync($"{_httpClient.BaseAddress}/GymEquipments/PutGymEquipmentBackEnd/{id}", jsonContent).Result;

            if (jsonResponse.IsSuccessStatusCode)
            {
                // Equipment created successfully, you can redirect to the equipment list or a success page.
                return RedirectToAction("Index");
            }
            else
            {
                // Handle the case where creating the equipment was not successful.
                ModelState.AddModelError(string.Empty, "Error Editing equipment.");
            }


            return View(equipment);
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult DeleteGet(int id)
        {
            EquipmentViewModel equipment = new EquipmentViewModel();
            HttpResponseMessage response = _httpClient.GetAsync($"{_httpClient.BaseAddress}/GymEquipments/GetGymEquipmentBackEnd/{id}").Result;
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

                var response = _httpClient.DeleteAsync($"{_httpClient.BaseAddress}/GymEquipments/DeleteGymEquipmentBackEnd/{id}").Result;

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

            return View("Index", "Equipment");
        }
    }
}
