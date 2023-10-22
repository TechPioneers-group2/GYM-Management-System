using gym_management_system_front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index()
        {
            List<SupplementViewModel> supplementList = new List<SupplementViewModel>();
            var response = await _client.GetAsync(_client.BaseAddress + "/GetSupplementsBackEnd");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                supplementList = JsonConvert.DeserializeObject<List<SupplementViewModel>>(data);
            }

            return View(supplementList);
        }

        [HttpGet]
        public async Task<IActionResult> ClientIndex()
        {
            List<SupplementViewModel> supplementList = new List<SupplementViewModel>();
            var response = await _client.GetAsync(_client.BaseAddress + "/GetSupplementsBackEnd");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                supplementList = JsonConvert.DeserializeObject<List<SupplementViewModel>>(data);
            }

            return View(supplementList);
        }

        public async Task<ActionResult<SupplementViewModel>> Details(int id)
        {
            var supplementViewModel = new SupplementViewModel();
            var response = await _client.GetAsync(_client.BaseAddress + "/GetSupplementBackEnd/" + id);

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
        public async Task<IActionResult> Create(SupplementViewModel supplementViewModel, IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    var streamcontent = new StreamContent(file.OpenReadStream());
                    streamcontent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

                    var imageContent = new MultipartFormDataContent
                    {
                        { streamcontent, "file", file.FileName }
                    };

                    var imageResponse = await _client.PostAsync("https://localhost:7200/api/Methods/AddImageToCloud", imageContent);
                    supplementViewModel.imageURL = await imageResponse.Content.ReadAsStringAsync();
                }

                var jsonContent = new StringContent(JsonConvert.SerializeObject(supplementViewModel), Encoding.UTF8, "application/json");
                var response = await _client.PostAsync(_client.BaseAddress + "/PostSupplementBackEnd", jsonContent);
                var data = await response.Content.ReadAsStringAsync();
                supplementViewModel = JsonConvert.DeserializeObject<SupplementViewModel>(data);

                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "Supplement Created successfully";
                    return RedirectToAction("Index", "Supplement");
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "An error occurred while creating the supplement.";
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
        public async Task<IActionResult> Edit(SupplementViewModel supplementViewModel, IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    var streamcontent = new StreamContent(file.OpenReadStream());
                    streamcontent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

                    var imageContent = new MultipartFormDataContent
                    {
                        { streamcontent, "file", file.FileName }
                    };

                    var imageResponse = await _client.PostAsync("https://localhost:7200/Methods/AddImageToCloud", imageContent);
                    supplementViewModel.imageURL = await imageResponse.Content.ReadAsStringAsync();
                }

                var json = JsonConvert.SerializeObject(supplementViewModel);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _client.PutAsync(_client.BaseAddress + "/PutSupplementBackEnd/" + supplementViewModel.SupplementID, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "Supplement Updated successfully";
                    return RedirectToAction("Index", "Supplement");
                }

                TempData["error"] = "Failed to update supplement. Please try again.";
                return RedirectToAction("Index", "Supplement");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
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

                var response = await _client.DeleteAsync(_client.BaseAddress + "/DeleteSupplementBackEnd/" + SupplementID);

                if (response.IsSuccessStatusCode)
                {
                    TempData["success"] = "Supplement Deleted successfully";
                    return RedirectToAction("Index", "Supplement");
                }

                TempData["error"] = "Delete Process failed";
                return RedirectToAction("Index", "Supplement");
            }
            else
            {
                TempData["error"] = "An error occurred while deleting the supplement.";
                return NotFound();
            }
        }

        #region API CALLS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<SupplementViewModel> supplementList = new List<SupplementViewModel>();
            var response = await _client.GetAsync(_client.BaseAddress + "/GetSupplementsBackEnd");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                supplementList = JsonConvert.DeserializeObject<List<SupplementViewModel>>(data);
            }

            return Json(new { data = supplementList });
        }
        #endregion
    }
}
