using gym_management_system_front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace gym_management_system_front_end.Controllers
{
    public class SubscriptionTiersController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7200/api/SubscriptionTiers");
        private readonly HttpClient _client;

        public SubscriptionTiersController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            List<SubscriptionTiersViewModel> ListsubscriptionTiers = new List<SubscriptionTiersViewModel>();

            var response = _client.GetAsync(_client.BaseAddress + "/GetSubscriptionTiersBackEnd").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                // Check if the data is an object with an 'errors' property
                if (data.Contains("errors"))
                {
                    // Handle the error or invalid response here
                    // You can return an error view or take appropriate action
                    // based on your application's logic.
                }
                else
                {
                    // Assuming the data is an array of subscription tiers
                    ListsubscriptionTiers = JsonConvert.DeserializeObject<List<SubscriptionTiersViewModel>>(data);
                }
            }
            else
            {
                // Handle the response when the HTTP request is not successful
                // You can return an error view or take appropriate action based on your application's logic.
            }

            return View(ListsubscriptionTiers);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            SubscriptionTiersViewModel sub = new SubscriptionTiersViewModel();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/GetSubscriptionTierBackEnd/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string Data = response.Content.ReadAsStringAsync().Result;
                sub = JsonConvert.DeserializeObject<SubscriptionTiersViewModel>(Data);
            }
            return View(sub);


        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int SubscriptionTierID)
        {
            try
            {
                // Construct the full URL for the DELETE request
                string deleteUrl = $"{_client.BaseAddress}/DeleteSubscriptionTierBackEnd/{SubscriptionTierID}";

                // Send the HTTP DELETE request
                HttpResponseMessage response = await _client.DeleteAsync(deleteUrl);


                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // The resource has been successfully deleted
                    // You can handle the success case here, e.g., return a success response or redirect
                    return RedirectToAction("Index");
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


        [HttpGet]
        public IActionResult Edit(int id)
        {
            CreatSubscriptionTierDTO model = new CreatSubscriptionTierDTO();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/GetSubscriptionTierBackEnd" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string Data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<CreatSubscriptionTierDTO>(Data);
            }
            return View(model);
        }

        [HttpPost]

        public IActionResult Edit(int id, UpdateSubscriptionTierDTO updateSubscriptionTierDTO)
        {
            // Serialize the DTO to JSON
            string data = JsonConvert.SerializeObject(updateSubscriptionTierDTO);

            // Create the URL for the PUT request
            string url = _client.BaseAddress + $"/PutSubscriptionTierBackEnd/{id}";

            // Create the request content
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            // Send the PUT request
            HttpResponseMessage response = _client.PutAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatSubscriptionTierDTO subscriptionTier)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(subscriptionTier), Encoding.UTF8, "application/json");


            var response = _client.PostAsync(_client.BaseAddress + "/PostSubscriptionTierBackEnd", jsonContent).Result;


            var data = response.Content.ReadAsStringAsync().Result;
            subscriptionTier = JsonConvert.DeserializeObject<CreatSubscriptionTierDTO>(data);

            return RedirectToAction("Index");
        }
    }
}