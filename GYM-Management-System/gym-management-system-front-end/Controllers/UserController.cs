using gym_management_system_front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace gym_management_system_front_end.Controllers
{
    public class UserController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7200/api/User/");
        private readonly HttpClient _client;

        public UserController(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = baseAddress;
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LogInDTO logInDTO)
        {
            var json = JsonConvert.SerializeObject(logInDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(baseAddress + "Login", data);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var userDTO = JsonConvert.DeserializeObject<UserDTO>(result);

                Response.Cookies.Append("JWTToken", userDTO.Token, new CookieOptions
                {
                    HttpOnly = true
                });

            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAdmin(RegisterAdminDTO adminDTO)
        {
            adminDTO.Roles = new List<string>
            {
                "Admin"
            };

            var json = JsonConvert.SerializeObject(adminDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(baseAddress + "RegisterAdmin", data);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var userDTO = JsonConvert.DeserializeObject<UserDTO>(result);

                Response.Cookies.Append("JWTToken", userDTO.Token, new CookieOptions
                {
                    HttpOnly = true
                });

                return RedirectToAction("Index", "Home");
            }

            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                var errorDetails = JsonConvert.DeserializeObject<ValidationProblemDetails>(errorResponse);
                foreach (var error in errorDetails.Errors)
                {
                    ModelState.AddModelError(error.Key, string.Join("", error.Value));
                }
            }
            return View(adminDTO);
        }

        public IActionResult RegisterEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterEmployee(RegisterEmployeeDTO employeeDTO)
        {
            employeeDTO.Roles = new List<string>
            {
                "Employee"
            };
            var json = JsonConvert.SerializeObject(employeeDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(baseAddress + "RegisterEmployee", data);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var userDTO = JsonConvert.DeserializeObject<UserDTO>(result);

                Response.Cookies.Append("JWTToken", userDTO.Token, new CookieOptions
                {
                    HttpOnly = true
                });

                return RedirectToAction("Index", "Home");
            }

            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                var errorDetails = JsonConvert.DeserializeObject<ValidationProblemDetails>(errorResponse);
                foreach (var error in errorDetails.Errors)
                {
                    ModelState.AddModelError(error.Key, string.Join("", error.Value));
                }
            }

            return View(employeeDTO);
        }

        public IActionResult RegisterClient()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterClient(RegisterClientDTO clientDTO)
        {

            var json = JsonConvert.SerializeObject(clientDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(baseAddress + "ClientRegister", data);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var userDTO = JsonConvert.DeserializeObject<UserDTO>(result);

                Response.Cookies.Append("JWTToken", userDTO.Token, new CookieOptions
                {
                    HttpOnly = true
                });

                return RedirectToAction("Index", "Home");
            }

            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                var errorDetails = JsonConvert.DeserializeObject<ValidationProblemDetails>(errorResponse);
                foreach (var error in errorDetails.Errors)
                {
                    ModelState.AddModelError(error.Key, string.Join("", error.Value));
                }
            }

            return View(clientDTO);
        }

    }
}
