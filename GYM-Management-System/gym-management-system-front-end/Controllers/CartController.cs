using gym_management_system_front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stripe.Checkout;
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

        public async Task<ActionResult> AddToCart(int id)
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
                supplement = new Dictionary<int, int>
                   {
                       { id, 1 }
                   };
            }

            var option = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7)

            };
            HttpContext.Response.Cookies.Append("SupplementCart", JsonConvert.SerializeObject(supplement), option);

            string refURL = Request.Headers["Referer"].ToString();

            return Redirect(refURL);
        }


        public ActionResult RemoveFromCart(int id)
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

                var option = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(7)

                };
                HttpContext.Response.Cookies.Append("SupplementCart", JsonConvert.SerializeObject(supplement), option);
            }
            string refURL = Request.Headers["Referer"].ToString();

            return Redirect(refURL);

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


    }
}
