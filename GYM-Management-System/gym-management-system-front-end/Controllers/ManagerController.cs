using Microsoft.AspNetCore.Mvc;

namespace gym_management_system_front_end.Controllers
{
    public class Manager : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
