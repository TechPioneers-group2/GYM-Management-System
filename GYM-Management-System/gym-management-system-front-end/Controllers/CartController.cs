using gym_management_system_front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Web;

namespace gym_management_system_front_end.Controllers
{
    public class CartController : Controller
    {

        private Uri baseAddress = new Uri("https://localhost:7200/api/Supplements");

        private readonly HttpClient _client;


        public CartController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {

            var sup = GetCartFromCookies();

            return View(sup);
        }

        [HttpPost]
        public async Task<ActionResult> AddToCart(int supplementID)
        {

            // Retrieve cart items from cookies
            var cart = GetCartFromCookies(); 
          
            var supplement = new SupplementViewModel();
            var response = await _client.GetAsync(_client.BaseAddress + "/GetSupplement/" + supplementID);
            
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                supplement = JsonConvert.DeserializeObject<SupplementViewModel>(data);
            }

            
                cart.Add(supplement);

                // Add the new item to the cart
                SaveCartToCookies(cart);

            
            

               
            

            return Redirect("/#Supplements");
        }
        private List<SupplementViewModel> GetCartFromCookies()
        {
            var cartCookie = HttpContext.Request.Cookies["ShoppingCart"];
            if (cartCookie != null)
            {
                var cartJson = HttpUtility.UrlDecode(cartCookie);
                return JsonConvert.DeserializeObject<List<SupplementViewModel>>(cartJson);
            }
            return new List<SupplementViewModel>();
        }

        public ActionResult RemoveFromCart(int supplementID)
        {
            // Retrieve cart items from cookies
            var cart = GetCartFromCookies();

            // Remove the item from the cart
            var itemToRemove = cart.FirstOrDefault(x=>x.SupplementID== supplementID);
            if (itemToRemove != null)
            {
                cart.Remove(itemToRemove);
            }

            // Save the updated cart to cookies
            SaveCartToCookies(cart);

            return RedirectToAction("Index");
        }


        private void SaveCartToCookies(List<SupplementViewModel> supplements)
        {
            var supplementsJson = JsonConvert.SerializeObject(supplements);
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7) // Adjust the expiration as needed
            };
            Response.Cookies.Append("ShoppingCart", HttpUtility.UrlEncode(supplementsJson), cookieOptions);
        }
    }
}
