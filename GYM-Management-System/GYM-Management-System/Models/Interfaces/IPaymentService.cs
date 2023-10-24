using GYM_Management_System.Models.DTOs;
using Stripe.Checkout;

namespace GYM_Management_System.Models.Interfaces
{
    public interface IPaymentService
    {
       // Task<Session> PaymentProcess(List<CartViewModel> carts);
        Task<Session> SubTierPaymentProcess(GetSubscriptionTierDTO subTier);

    }
}
