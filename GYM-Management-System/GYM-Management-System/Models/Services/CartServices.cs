using GYM_Management_System.Data;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stripe;
using Stripe.Issuing;
using System.Security.Claims;

namespace GYM_Management_System.Models.Services
{
    public class CartServices : ICart
    {
        private readonly GymDbContext  _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public CartServices(GymDbContext context , IHttpContextAccessor httpContextAccessor, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor; 
            _signInManager = signInManager;
        }
        public async Task<List<CartSupp>> AddToCart(SupplementDTO supplement)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

             if (string.IsNullOrEmpty(userId))
             {
                 return null;
             }
             var userCart = await _context.Cart.FirstOrDefaultAsync(c => c.UserId == userId);
             if (userCart == null)
             {
                 return null;
             }
             var CartofUser = await _context.Cart.Where(x => x.UserId == userId).SelectMany(x => x.CartSupp).FirstOrDefaultAsync(x => x.SupplementId == supplement.SupplementID);
             //var CartProduct = userCart?.CartProducts?.FirstOrDefault(cp => cp.Product.Id == product.Id);

             if (CartofUser != null)
             {
                 CartofUser.Quantity += 1;
             }
             else
             {
                // If the product is not in the Cart, add it.
                Supplement sup = new Supplement
                {
                   Name = supplement.Name,
                   SupplementID=supplement.SupplementID,
                   Description = supplement.Description,
                   imageURL=supplement.imageURL,
                   Price=supplement.Price


                 };
                 CartofUser = new CartSupp
                 {
                     Cart = userCart, // This should work with the updated ForeignKey attribute.
                     SupplementId = sup.SupplementID,
                     Quantity = 1,
                     UserId = userId,
                 };
                 _context.CartSupp.Add(CartofUser);
                 await _context.SaveChangesAsync();
             }


             await _context.SaveChangesAsync();


             return userCart.CartSupp;
           
        }
        public async Task<CartViewModel> GetCart(string userId)
        {
            var userCart = await _context.Cart
                .Include(c => c.CartSupp)
                .ThenInclude(cp => cp.supplement)
                .FirstOrDefaultAsync(c => c.UserId == userId);


            return userCart;




        }
    }
}
