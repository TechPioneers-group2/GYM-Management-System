using gym_management_system_front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gym_management_system_front_end.Controllers
{
    public class ClientsController : Controller
    {
        private Uri baseAddress = new Uri("https://localhost:7200/api/Clients");
        private readonly HttpClient _client;

        public ClientsController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index(int gymid)
        {
            List<ClientViewModel> clientList = new List<ClientViewModel>();
            var response = _client.GetAsync(_client.BaseAddress + "/GetClientsBackEnd/gym/" + gymid).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                clientList = JsonConvert.DeserializeObject<List<ClientViewModel>>(data);
            }

            return View(clientList);
        }

        public async Task<ActionResult<ClientViewModel>> Details(int clientID, int gymID)
        {
            var clientViewModel = new ClientViewModel();
            HttpResponseMessage response = _client.GetAsync($"{_client.BaseAddress}/GetClientBackEnd/{clientID}/gym/{gymID}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                clientViewModel = JsonConvert.DeserializeObject<ClientViewModel>(data);
            }

            return View(clientViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int clientID, int gymID)
        {
            ClientViewModel model = new ClientViewModel();
            HttpResponseMessage response = _client.GetAsync($"{_client.BaseAddress}/GetClientBackEnd/{clientID}/gym/{gymID}").Result;
            if (response.IsSuccessStatusCode)
            {
                string Data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<ClientViewModel>(Data);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int clientID, int gymID, UpdateClientDTO clientDTO)
        {
            string data = JsonConvert.SerializeObject(clientDTO);

            // Create the URL for the PUT request
            string url = _client.BaseAddress + "/PutClientBackEnd/" + clientID + "/gym/" + gymID;

            // Create the request content
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            // Send the PUT request
            HttpResponseMessage response = _client.PutAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Client Updated successfully";
                return RedirectToAction("Index", new { gymID = gymID });
            }

            TempData["error"] = "Failed to update client. Please try again.";
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int clientID, int gymID)
        {
            ClientViewModel del = new ClientViewModel();
            HttpResponseMessage response = _client.GetAsync($"{_client.BaseAddress}/GetClientBackEnd/{clientID}/gym/{gymID}").Result;
            if (response.IsSuccessStatusCode)
            {
                string Data = response.Content.ReadAsStringAsync().Result;
                del = JsonConvert.DeserializeObject<ClientViewModel>(Data);
            }
            return View(del);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int clientID, int gymID)
        {
            try
            {
                // Construct the full URL for the DELETE request
                string deleteUrl = $"{_client.BaseAddress}/DeleteClientBackEnd/{clientID}/gym/{gymID}";

                // Send the HTTP DELETE request
                HttpResponseMessage response = await _client.DeleteAsync(deleteUrl);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "Client Deleted successfully";
                    return RedirectToAction("Index", new { gymID = gymID });
                }
                else
                {
                    TempData["error"] = "Failed to delete client. Please try again.";
                    return RedirectToAction("Index", new { gymID = gymID });
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "An error occurred while processing your request.";
                return View("Error");
            }
        }
    }
}
