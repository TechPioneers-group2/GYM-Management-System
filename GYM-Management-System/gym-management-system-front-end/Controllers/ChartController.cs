using gym_management_system_front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace gym_management_system_front_end.Controllers
{
    public class ChartController : Controller
    {
        private Uri baseAddress = new Uri("https://gym-management-system.azurewebsites.net/api/");
        private readonly HttpClient _client;

        public ChartController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Chart()
        {
            // Retrieve client data
            List<ClientViewModel> clientList = new List<ClientViewModel>();
            var clientResponse = _client.GetAsync(_client.BaseAddress + "Clients/GetAllClientsBackEnd/").Result;

            if (clientResponse.IsSuccessStatusCode)
            {
                string clientData = clientResponse.Content.ReadAsStringAsync().Result;
                clientList = JsonConvert.DeserializeObject<List<ClientViewModel>>(clientData);
            }

            // Retrieve equipment data
            List<EquipmentViewModel> equipmentList = new List<EquipmentViewModel>();
            var equipmentResponse = _client.GetAsync(_client.BaseAddress + "GymEquipments/GetBackEnd").Result;

            if (equipmentResponse.IsSuccessStatusCode)
            {
                string equipmentData = equipmentResponse.Content.ReadAsStringAsync().Result;
                equipmentList = JsonConvert.DeserializeObject<List<EquipmentViewModel>>(equipmentData);
            }

            // Calculate counts for clients in the gym and not in the gym
            int clientsInGymCount = clientList.Count(c => c.InGym);
            int clientsNotInGymCount = clientList.Count(c => !c.InGym);

            // Calculate counts for equipment out of service and not out of service
            int outOfServiceCount = equipmentList.Count(equipment => equipment.OutOfService == 1);
            int notOutOfServiceCount = equipmentList.Count(equipment => equipment.OutOfService == 0);

            // Pass the counts and data to the view
            ViewBag.ClientsInGymCount = clientsInGymCount;
            ViewBag.ClientsNotInGymCount = clientsNotInGymCount;

            ViewBag.OutOfServiceCount = outOfServiceCount;
            ViewBag.NotOutOfServiceCount = notOutOfServiceCount;

            return View(new ChartDataViewModel
            {
                ClientList = clientList,
                EquipmentList = equipmentList
            });
        }
    }
}
