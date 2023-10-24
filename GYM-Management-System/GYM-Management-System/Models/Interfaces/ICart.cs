using GYM_Management_System.Models.DTOs;

namespace GYM_Management_System.Models.Interfaces
{
    public interface ICart
    {
        Task<List<CartSupp>> AddToCart(SupplementDTO supplement);
        Task<CartViewModel> GetCart(string userId);
    }
}
