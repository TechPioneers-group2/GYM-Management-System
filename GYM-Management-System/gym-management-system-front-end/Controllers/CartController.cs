using Azure;
using GYM_Management_System.Models;
using gym_management_system_front_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Web;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task<IActionResult> Index()
        {
            var cart = HttpContext.Request.Cookies["SupplementCart"];
            var dicCart = JsonConvert.DeserializeObject<Dictionary<int, int>>(cart);
            var cartItems = new List<CartViewModel>();

            foreach(var item in dicCart)
            {
                var res = await _client.GetAsync(_client.BaseAddress + "/GetSupplement/" + item.Key);
                var jsondata = await res.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<SupplementViewModel>(jsondata);
                int y;
                dicCart.TryGetValue(product.SupplementID,out y);
                var x = new CartViewModel
                {
                    SupplementID = product.SupplementID,
                    imageURL=product.imageURL,
                    Description=product.Description,
                    Price=product.Price,
                    Name=product.Name,
                    Quantity=y
                };
                cartItems.Add(x);
            }

            return View(cartItems);
            
        }

        [HttpPost]
        public async Task<ActionResult> AddToCart(int supplementID)
        {

            var cartCookie = HttpContext.Request.Cookies["SupplementCart"];
            Dictionary<int, int> supplement;
            if (cartCookie != null)
            {
                supplement = JsonConvert.DeserializeObject<Dictionary<int, int>>(cartCookie);


                if (supplement.ContainsKey(supplementID))
                {
                    supplement[supplementID] += 1;
                }
                else
                {
                    supplement[supplementID] = 1;
                }

            }
            else
            {
                supplement = new Dictionary<int, int>
                   {
                       { supplementID, 1 }
                   };
            }

            var option = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7)

            };
            HttpContext.Response.Cookies.Append("SupplementCart", JsonConvert.SerializeObject(supplement),option) ;

            string refURL = Request.Headers["Referer"].ToString();

            return Redirect(refURL);
        }


        public ActionResult RemoveFromCart(int supplementID)
        {
            var removed = HttpContext.Request.Cookies["SupplementCart"];
            Dictionary<int, int> supplement;
            if (removed != null)
            {
                supplement = JsonConvert.DeserializeObject<Dictionary<int, int>>(removed);


                if (supplement.ContainsKey(supplementID))
                {
                    supplement[supplementID] -= 1;
                }
                if (supplement[supplementID] <= 0)
                {
                    supplement.Remove(supplementID);
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

    }
}
