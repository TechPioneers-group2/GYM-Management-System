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

                if (data.Contains("errors"))
                {
                    TempData["error"] = "Error while fetching subscription tiers.";
                }
                else
                {
                    ListsubscriptionTiers = JsonConvert.DeserializeObject<List<SubscriptionTiersViewModel>>(data);
                }
            }
            else
            {
                TempData["error"] = "Error while fetching subscription tiers.";
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
                string deleteUrl = $"{_client.BaseAddress}/DeleteSubscriptionTierBackEnd/{SubscriptionTierID}";
                HttpResponseMessage response = await _client.DeleteAsync(deleteUrl);

                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "Subscription tier deleted successfully.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Failed to delete subscription tier. Please try again.";
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "An error occurred while deleting the subscription tier.";
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CreatSubscriptionTierDTO model = new CreatSubscriptionTierDTO();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/GetSubscriptionTierBackEnd/" + id).Result;
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
            string data = JsonConvert.SerializeObject(updateSubscriptionTierDTO);
            string url = _client.BaseAddress + $"/PutSubscriptionTierBackEnd/{id}";
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PutAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Subscription tier updated successfully.";
                return RedirectToAction("Index");
            }

            TempData["error"] = "Failed to update subscription tier. Please try again.";
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

            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Subscription tier created successfully.";
            }
            else
            {
                TempData["error"] = "Failed to create subscription tier. Please try again.";
            }

            return RedirectToAction("Index");
        }
    }
}
