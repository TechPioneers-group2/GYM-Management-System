using gym_management_system_front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Text;

namespace gym_management_system_front_end.Controllers
{
    public class EmployeesController : Controller
    {
        Uri baseAddress = new Uri("https://gym-management-system.azurewebsites.net/api");

        private readonly HttpClient _client;

        public EmployeesController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            List<EmployeeViewModel> employeesList = new List<EmployeeViewModel>();
            var response = _client.GetAsync(_client.BaseAddress + "/Employees/GetEmployeesBackEnd").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                employeesList = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(data);
            }
            var gymList = GetGymsList();
            ViewBag.gymList = gymList;
            ViewBag.Employees = "All";
            return View(employeesList);
        }

        [HttpPost]
        public IActionResult GetEmployeesByGymId(int gymId)
        {
            List<EmployeeViewModel> employeesList = new List<EmployeeViewModel>();
            var response = _client.GetAsync(_client.BaseAddress + "/Employees/GetEmployeesByGymIdBackEnd/" + gymId).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                employeesList = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(data);
            }
            var gymList = GetGymsList();
            ViewBag.gymList = gymList;
            foreach (var gym in gymList)
            {
                if (gym.GymID == gymId)
                {
                    ViewBag.gymName = gym.Name;
                }
            }
            return View(employeesList);
        }

        public IActionResult GetEmployee(int id)
        {
            EmployeeViewModel employee = new EmployeeViewModel();
            var response = _client.GetAsync(_client.BaseAddress + "/Employees/GetEmployeeBackEnd/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<EmployeeViewModel>(data);
            }
            return View(employee);
        }

        public IActionResult Create()
        {
            var gymList = GetGymsList();
            ViewBag.gymList = gymList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  Create(RegisterEmployeeViewModel registerEmployeeViewModel)
        {
            registerEmployeeViewModel.UserId = string.Empty;
            registerEmployeeViewModel.UserName = registerEmployeeViewModel.Name;
            var jsonContent = new StringContent(JsonConvert.SerializeObject(registerEmployeeViewModel), Encoding.UTF8, "application/json");
            var response = await  _client.PostAsync(_client.BaseAddress + "/User/RegisterEmployeeBackEnd", jsonContent);
            var data =await response.Content.ReadAsStringAsync();
            var employee = JsonConvert.DeserializeObject<UserDTO>(data);

            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Employee created successfully";
            }
            else
            {
                TempData["error"] = "Failed to create employee. Please try again.";
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _client.DeleteAsync(_client.BaseAddress + "/Employees/DeleteEmployeeBackEnd/" + id);

            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Employee deleted successfully";
            }
            else
            {
                TempData["error"] = "Failed to delete employee. Please try again.";
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var actionResult = GetEmployee(id);
            if (actionResult is ViewResult viewResult)
            {
                var employee = viewResult.Model as EmployeeViewModel;

                if (employee == null)
                {
                    return NotFound();
                }
                var gymList = GetGymsList();
                ViewBag.gymList = gymList;
                return View(employee);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel employeeViewModel)
        {
            UpdateEmployeeViewModel updateEmployeeViewModel = (UpdateEmployeeViewModel)employeeViewModel;

            var json = JsonConvert.SerializeObject(updateEmployeeViewModel);

            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(_client.BaseAddress + "/Employees/PutEmployeeBackEnd/" + employeeViewModel.EmployeeID, stringContent);

            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Employee updated successfully";
            }
            else
            {
                TempData["error"] = "Failed to update employee. Please try again.";
            }

            return RedirectToAction("Index");
        }

        public List<GymViewModel> GetGymsList()
        {
            Uri baseAddress = new Uri("https://gym-management-system.azurewebsites.net/api/Gyms");

            List<GymViewModel> gymList = new List<GymViewModel>();
            var response = _client.GetAsync(_client.BaseAddress + "/Gyms/GetGymsBackEnd").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                gymList = JsonConvert.DeserializeObject<List<GymViewModel>>(data);
            }
            return gymList;
        }
    }
}
