using gym_management_system_front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stripe.Checkout;
using System.Security.Claims;
using System.Text;

namespace gym_management_system_front_end.Controllers
{
    public class CartController : Controller
    {

        private Uri baseAddress = new Uri("https://localhost:7200/api/");

        private readonly HttpClient _client;

        public CartController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var cart = HttpContext.Request.Cookies["SupplementCart"];
                var dicCart = JsonConvert.DeserializeObject<Dictionary<int, int>>(cart);
                var cartItems = new List<CartViewModel>();

                foreach (var item in dicCart)
                {
                    var res = await _client.GetAsync(_client.BaseAddress + "Supplements/GetSupplementBackEnd/" + item.Key);
                    var jsondata = await res.Content.ReadAsStringAsync();
                    var product = JsonConvert.DeserializeObject<SupplementViewModel>(jsondata);
                    int y;
                    dicCart.TryGetValue(product.SupplementID, out y);
                    var x = new CartViewModel
                    {
                        SupplementID = product.SupplementID,
                        imageURL = product.imageURL,
                        Description = product.Description,
                        Price = product.Price,
                        Name = product.Name,
                        Quantity = y
                    };
                    cartItems.Add(x);
                }

                return View(cartItems);
            }
            catch
            {
                return View(null);
            }
        }

        public async Task<ActionResult> AddToCart(int id)
        {
            try
            {
                var cartCookie = HttpContext.Request.Cookies["SupplementCart"];
                Dictionary<int, int> supplement;
                if (cartCookie != null)
                {
                    supplement = JsonConvert.DeserializeObject<Dictionary<int, int>>(cartCookie);

                    if (supplement.ContainsKey(id))
                    {
                        supplement[id] += 1;
                    }
                    else
                    {
                        supplement[id] = 1;
                    }
                }
                else
                {
                    supplement = new Dictionary<int, int> { { id, 1 } };
                }

                var option = new CookieOptions { Expires = DateTime.Now.AddDays(7) };
                HttpContext.Response.Cookies.Append("SupplementCart", JsonConvert.SerializeObject(supplement), option);

                TempData["success"] = "Item successfully added to the cart.";
                string refURL = Request.Headers["Referer"].ToString();
                return Redirect(refURL);
            }
            catch
            {
                TempData["error"] = "An error occurred while adding the item to the cart.";
                string refURL = Request.Headers["Referer"].ToString();
                return Redirect(refURL);
            }
        }

        public ActionResult RemoveFromCart(int id)
        {
            try
            {
                var removed = HttpContext.Request.Cookies["SupplementCart"];
                Dictionary<int, int> supplement;
                if (removed != null)
                {
                    supplement = JsonConvert.DeserializeObject<Dictionary<int, int>>(removed);

                    if (supplement.ContainsKey(id))
                    {
                        supplement[id] -= 1;
                    }
                    if (supplement[id] <= 0)
                    {
                        supplement.Remove(id);
                    }

                    var option = new CookieOptions { Expires = DateTime.Now.AddDays(7) };
                    HttpContext.Response.Cookies.Append("SupplementCart", JsonConvert.SerializeObject(supplement), option);
                }

                TempData["success"] = "Item successfully removed from the cart.";
                string refURL = Request.Headers["Referer"].ToString();
                return Redirect(refURL);
            }
            catch
            {
                TempData["error"] = "An error occurred while removing the item from the cart.";
                string refURL = Request.Headers["Referer"].ToString();
                return Redirect(refURL);
            }
        }

        public ActionResult RemoveAllFromCart(int id)
        {
            try
            {
                var removed = HttpContext.Request.Cookies["SupplementCart"];
                Dictionary<int, int> supplement;
                if (removed != null)
                {
                    supplement = JsonConvert.DeserializeObject<Dictionary<int, int>>(removed);

                    if (supplement.ContainsKey(id))
                    {
                        supplement.Remove(id);
                    }

                    var option = new CookieOptions { Expires = DateTime.Now.AddDays(7) };
                    HttpContext.Response.Cookies.Append("SupplementCart", JsonConvert.SerializeObject(supplement), option);
                }

                TempData["success"] = "All items of this type successfully removed from the cart.";
                string refURL = Request.Headers["Referer"].ToString();
                return Redirect(refURL);
            }
            catch
            {
                TempData["error"] = "An error occurred while removing items from the cart.";
                string refURL = Request.Headers["Referer"].ToString();
                return Redirect(refURL);
            }
        }

        public async Task<IActionResult> CheckOut()
        {
            // Fetch the cart items from the Index method
            var itemlist = (ViewResult)await Index();
            var cartItems = (List<CartViewModel>)itemlist.Model;

            // Use an HttpClient to send a POST request to your API
            using (HttpClient client = new HttpClient())
            {
                // Set your API base URL here

                // Serialize the cart items to JSON
                string jsonCartItems = JsonConvert.SerializeObject(cartItems);
                HttpContent content = new StringContent(jsonCartItems, Encoding.UTF8, "application/json");

                // Send an HTTP POST request to the API Controller endpoint
                HttpResponseMessage response = await client.PostAsync(_client.BaseAddress + "Methods/PaymentBackEnd", content);

                if (response.IsSuccessStatusCode)
                {

                    var jsondata = await response.Content.ReadAsStringAsync();
                    var se = JsonConvert.DeserializeObject<Session>(jsondata);
                    Response.Headers.Add("Location", se.Url);
                    //Response.Headers.Add("Location", jsondata);
                    return new StatusCodeResult(303);

                }
                else
                {
                    // Handle the API request failure, such as displaying an error message
                    // You can redirect to an error page or show an error message to the user
                    RedirectToAction("Index,Home");
                }

                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> summary()
        {
            var identity = (ClaimsIdentity)User.Identity;

            var usernameClaim = identity.FindFirst(ClaimTypes.Name)?.Value;
            var emailClaim = identity.FindFirst(ClaimTypes.Email)?.Value;
            var userIDClaim = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            try
            {
                var cart = HttpContext.Request.Cookies["SupplementCart"];
                var dicCart = JsonConvert.DeserializeObject<Dictionary<int, int>>(cart);
                var cartItems = new List<CartViewModel>();

                foreach (var item in dicCart)
                {
                    var res = await _client.GetAsync(_client.BaseAddress + "Supplements/GetSupplementBackEnd/" + item.Key);
                    var jsondata = await res.Content.ReadAsStringAsync();
                    var product = JsonConvert.DeserializeObject<SupplementViewModel>(jsondata);
                    int y;
                    dicCart.TryGetValue(product.SupplementID, out y);
                    var x = new CartViewModel
                    {
                        SupplementID = product.SupplementID,
                        imageURL = product.imageURL,
                        Description = product.Description,
                        Price = product.Price,
                        Name = product.Name,
                        Quantity = y
                    };
                    cartItems.Add(x);
                }

                var order = new OrderViewModel
                {
                    id = userIDClaim,
                    name = usernameClaim,
                    email = emailClaim,
                    cartViewModels = cartItems
                };

                Response.Cookies.Delete("SupplementCart");

                return View(order);
            }
            catch
            {
                return View(null);
            }
        }



    }
}
