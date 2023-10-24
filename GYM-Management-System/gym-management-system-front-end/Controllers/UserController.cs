using gym_management_system_front_end.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stripe.Checkout;
using System.Net;
using System.Security.Claims;
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
            var response = await _client.PostAsync(baseAddress + "LoginBackEnd", data);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var userDTO = JsonConvert.DeserializeObject<UserDTO>(result);

                // Create a ClaimsIdentity and add claims
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, userDTO.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, userDTO.Roles[0]));

                // Create a ClaimsPrincipal and sign in
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                Response.Cookies.Append("JWTToken", userDTO.Token, new CookieOptions
                {
                    HttpOnly = true
                });

                TempData["success"] = "Wellcome!";

                return RedirectToAction("Index", "Home");
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                var errorDetails = JsonConvert.DeserializeObject<ValidationProblemDetails>(errorResponse);
                foreach (var error in errorDetails.Errors)
                {
                    ModelState.AddModelError(error.Key, string.Join("", error.Value));
                }
                ModelState.AddModelError(string.Empty, "Wrong username or password.");
            }

            return LogIn();
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
            var response = await _client.PostAsync(baseAddress + "RegisterAdminBackEnd", data);

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

        public async Task<IActionResult> RegisterClient()
        {
            var gymResponse = await _client.GetAsync("https://localhost:7200/api/Gyms/GetGymsBackEnd");
            var gymResult = await gymResponse.Content.ReadAsStringAsync();
            var gymList = JsonConvert.DeserializeObject<List<GetUserGymDTO>>(gymResult);

            var idList = new List<GymIDDTO>();

            foreach (var item in gymList)
            {
                idList.Add(new GymIDDTO
                {
                    GymID = item.GymID,
                    Name = item.Name,
                });
            }

            var subTierResponse = await _client.GetAsync("https://localhost:7200/api/SubscriptionTiers/GetSubscriptionTiersBackEnd");
            var subTierResult = await subTierResponse.Content.ReadAsStringAsync();
            var subTierList = JsonConvert.DeserializeObject<List<GetSubscriptionTierDTO>>(subTierResult);

            var returnClientView = new RegisterClientDTO
            {
                GymIDsNames = idList,
                SubscriptionTierDTOs = subTierList
            };

            return View(returnClientView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterClient(RegisterClientDTO clientDTO)
        {
            clientDTO.UserId = string.Empty;
            clientDTO.Name = clientDTO.UserName;
            var json = JsonConvert.SerializeObject(clientDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(baseAddress + "ClientRegisterBackEnd", data);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var userDTO = JsonConvert.DeserializeObject<UserDTO>(result);

                Response.Cookies.Append("JWTToken", userDTO.Token, new CookieOptions
                {
                    HttpOnly = true
                });
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
            string jsonCartItems = JsonConvert.SerializeObject(clientDTO);
            HttpContent content = new StringContent(jsonCartItems, Encoding.UTF8, "application/json");
            var PaymentResponse = await _client.PostAsync("https://localhost:7200/api/Methods/SubTierPaymentBackEnd", content);

            if (response.IsSuccessStatusCode)
            {
                var jsondata = await PaymentResponse.Content.ReadAsStringAsync();
                var session = JsonConvert.DeserializeObject<Session>(jsondata);
                Response.Headers.Add("Location", session.Url);
                return new StatusCodeResult(303);
            }

            return View(clientDTO);
        }
    }
}
