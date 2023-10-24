using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GYM_Management_System.Data;
using GYM_Management_System.Models;
using GYM_Management_System.Models.Interfaces;
using System.Security.Claims;
using GYM_Management_System.Models.DTOs;

namespace GYM_Management_System.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartViewModelsController : ControllerBase
    {
        private readonly GymDbContext _context;
        private readonly ICart _cart;

        public CartViewModelsController(GymDbContext context , ICart cart)
        {
            _context = context;
            _cart = cart;
        }

        // POST: api/cart
        [HttpPost]
        public async Task<IActionResult> AddToCart(SupplementDTO supplement)
        {
            var cartItems = await _cart.AddToCart(supplement);

            if (cartItems != null)
            {
                return Ok(cartItems);
            }

            return BadRequest("Failed to add the item to the cart");
        }

        // GET: api/cart/{userId}
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(string userId)
        {
            var userCart = await _cart.GetCart(userId);

            if (userCart != null)
            {
                return Ok(userCart);
            }

            return NotFound($"Cart not found for user with ID: {userId}");
        }
    }
}
