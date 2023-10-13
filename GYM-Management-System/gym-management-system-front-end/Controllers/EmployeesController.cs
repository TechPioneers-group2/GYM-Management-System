using gym_management_system_front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace gym_management_system_front_end.Controllers
{
	public class EmployeesController : Controller
	{
		Uri baseAddress = new Uri("https://localhost:7200/api");
		

		private readonly HttpClient _client;
        public EmployeesController()
        {
			_client = new HttpClient();
			_client.BaseAddress = baseAddress;
			
		}
        public IActionResult Index()
		{
			List<EmployeeViewModel> employeesList = new List<EmployeeViewModel>();
			var response = _client.GetAsync(_client.BaseAddress + "/Employees/GetEmployees").Result;

			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				employeesList = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(data);
			}
			return View(employeesList);
		}

		public IActionResult GetEmployee(int id)
		{
			EmployeeViewModel employee = new EmployeeViewModel();
			var response = _client.GetAsync(_client.BaseAddress + "/Employees/GetEmployee/"+id).Result;

			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				employee = JsonConvert.DeserializeObject< EmployeeViewModel > (data);
			}
			return View(employee);
		}

        public IActionResult Create()
        {
			Uri baseAddress = new Uri("https://localhost:7200/api/Gyms");

			List<GymViewModel> gymList = new List<GymViewModel>();
			var response = _client.GetAsync(_client.BaseAddress+ "/Gyms/GetGyms").Result;

			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				gymList = JsonConvert.DeserializeObject<List<GymViewModel>>(data);
			}
			ViewBag.gymList= gymList;	
			return View();
        }

        [HttpPost]
        public IActionResult Create(RegisterEmployeeViewModel registerEmployeeViewModel)
        {
			List<string> Roles = new List<string>();
			registerEmployeeViewModel.UserId = "string";
			Roles.Add("Employee");
			registerEmployeeViewModel.Roles= Roles;	
            var jsonContent = new StringContent(JsonConvert.SerializeObject(registerEmployeeViewModel), Encoding.UTF8, "application/json");
            var response = _client.PostAsync(_client.BaseAddress + "/User/RegisterEmployee", jsonContent).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            var employee = JsonConvert.DeserializeObject<UserDTO>(data);
            return RedirectToAction("Index");
        }

		
		public async Task<IActionResult> Delete(int id)
		{
			
				var response = await _client.DeleteAsync(_client.BaseAddress + "/Employees/DeleteEmployee/" + id);

			return RedirectToAction("Index");

		}
	}
}
