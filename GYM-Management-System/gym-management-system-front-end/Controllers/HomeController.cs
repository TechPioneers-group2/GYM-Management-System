using gym_management_system_front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace gym_management_system_front_end.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _Client;
        private Uri baseAddress = new Uri("https://gym-management-system.azurewebsites.net/api/Methods/");
        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _Client = httpClient;
            _Client.BaseAddress = baseAddress;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RecieveEmail(EmailViewModel email)
        {
            var json = JsonConvert.SerializeObject(email);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            await _Client.PostAsync(_Client.BaseAddress + "RecieveEmail", stringContent);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
