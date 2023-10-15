using gym_management_system_front_end.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace gym_management_system_front_end.Controllers
{
    public class SupplementController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7200/api/Supplements");
        private readonly HttpClient _client;
        public SupplementController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<SupplementViewModel> supplementList = new List<SupplementViewModel>();
            var response = _client.GetAsync(_client.BaseAddress + "/GetSupplements").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                supplementList = JsonConvert.DeserializeObject<List<SupplementViewModel>>(data);
            }
            return View(supplementList);
        }

        // GET: SupplementController/Details/5
        public async Task<ActionResult<SupplementViewModel>> Details(int id)
        {
            var supplementViewModel = new SupplementViewModel();
            var response = await _client.GetAsync(_client.BaseAddress + "/GetSupplement/" + id);
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                supplementViewModel = JsonConvert.DeserializeObject<SupplementViewModel>(data);
            }
            return View(supplementViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(SupplementViewModel supplementViewModel)
        {
            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(supplementViewModel), Encoding.UTF8, "application/json");
                var response = _client.PostAsync(_client.BaseAddress + "/PostSupplement", jsonContent).Result;
                var data = response.Content.ReadAsStringAsync().Result;
                supplementViewModel = JsonConvert.DeserializeObject<SupplementViewModel>(data);
                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "Supplement Created successfully";
                    return RedirectToAction("Index", "Supplement");
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return View();
        }


        public async Task<IActionResult> Edit(int id)
        {
            var actionResult = await Details(id);
            if (actionResult.Result is ViewResult viewResult)
            {
                var supplement = viewResult.Model as SupplementViewModel;

                if (supplement == null)
                {
                    return NotFound();
                }
                return View(supplement);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SupplementViewModel supplementViewModel)
        {
            var json = JsonConvert.SerializeObject(supplementViewModel);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(_client.BaseAddress + "/PutSupplement/" + supplementViewModel.SupplementID, stringContent);
            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Supplement Updated successfully";
                return RedirectToAction("Index", "Supplement");
            }
            return RedirectToAction("Index", "Supplement");
        }

        // GET: SupplementController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var actionResult = await Details(id);
            if (actionResult.Result is ViewResult viewResult)
            {
                var supplement = viewResult.Model as SupplementViewModel;
                if (supplement == null)
                {
                    return NotFound();
                }
                return View(supplement);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int SupplementID)
        {
            var actionResult = await Details(SupplementID);
            if (actionResult.Result is ViewResult viewResult)
            {
                var supplement = viewResult.Model as SupplementViewModel;
                if (supplement == null)
                {
                    return NotFound();
                }
                var response = await _client.DeleteAsync(_client.BaseAddress + "/DeleteSupplement/" + SupplementID);

                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "Supplement Deleted successfully";
                    return RedirectToAction("Index", "Supplement");
                }
                return RedirectToAction("Index", "Supplement");
            }
            else
            {
                TempData["error"] = "Delete Process failed";
                return NotFound();
            }
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<SupplementViewModel> supplementList = new List<SupplementViewModel>();
            var response = _client.GetAsync(_client.BaseAddress + "/GetSupplements").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                supplementList = JsonConvert.DeserializeObject<List<SupplementViewModel>>(data);
            }
            return Json(new { data = supplementList });
        }

        #endregion
    }
}
