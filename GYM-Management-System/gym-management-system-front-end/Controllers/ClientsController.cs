using gym_management_system_front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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
            var response = _client.GetAsync(_client.BaseAddress + "/GetClients/gym/" + gymid).Result;

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
            HttpResponseMessage response = _client.GetAsync($"{_client.BaseAddress}/GetClient/{clientID}/gym/{gymID}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                clientViewModel = JsonConvert.DeserializeObject<ClientViewModel>(data);
            }
            return View(clientViewModel);
        }

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(int gymId, PostClientDTO client)
        //{
        //    var jsonContent = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "application/json");
        //    var response = await _client.PostAsync($"{_client.BaseAddress}/PostClient?gymId={gymId}", jsonContent);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        // Handle successful create here
        //        return RedirectToAction("Index");
        //    }
        //    return View(client);
        //}


        [HttpGet]
        public async Task<IActionResult> Edit(int clientID, int gymID)
        {
            ClientViewModel model = new ClientViewModel();
            HttpResponseMessage response = _client.GetAsync($"{_client.BaseAddress}/GetClient/{clientID}/gym/{gymID}").Result;
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
            string url = _client.BaseAddress + "/PutClient/" + clientID + "/gym/" + gymID;

            // Create the request content
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            // Send the PUT request
            HttpResponseMessage response = _client.PutAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { gymID = gymID });
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int clientID, int gymID)
        {
            ClientViewModel del = new ClientViewModel();
            HttpResponseMessage response = _client.GetAsync($"{_client.BaseAddress}/GetClient/{clientID}/gym/{gymID}").Result;
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
                string deleteUrl = $"{_client.BaseAddress}/DeleteClient/{clientID}/gym/{gymID}";

                // Send the HTTP DELETE request
                HttpResponseMessage response = await _client.DeleteAsync(deleteUrl);


                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // The resource has been successfully deleted
                    // You can handle the success case here, e.g., return a success response or redirect
                    return RedirectToAction("Index", new { gymID = gymID });
                }
                else
                {
                    // Handle the case where the deletion was not successful, e.g., return an error view or display an error message.
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during the request
                // You might want to log the exception for debugging and return an error view
                return View("Error");
            }
        }


    }


}

