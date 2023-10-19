using GYM_Management_System.Models.Interfaces;
using Stripe;
using Stripe.Checkout;

namespace GYM_Management_System.Models.Services
{
    public class PaymentService : IPaymentService
    {
        public async Task<Session> PaymentProcess(List<CartViewModel> carts)
        {
            StripeConfiguration.ApiKey = "sk_test_51Nu9apGTsxCj81xc4G7NzFGmwMldXKwNwRsxl2dQdabXZJ8VITVSQlpREi0j8qy8qQwdMKPo0FhOVvvUlst2Bi8900rdC6MHnn";

            string domain = "https://localhost:7034";

            var options = new SessionCreateOptions
            {
                SuccessUrl = domain,
                CancelUrl = domain,
                Mode = "payment",
                LineItems = new List<SessionLineItemOptions>()
            };

            foreach (var item in carts)
            {
                var sessionLineItem = new SessionLineItemOptions()
                {
                    Quantity = item.Quantity,

                    PriceData = new SessionLineItemPriceDataOptions()
                    {
                        UnitAmount = (long)(item.Price * 100),
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions()
                        {
                            Name = item.Name
                        }
                    }
                };
                options.LineItems.Add(sessionLineItem);
            };
            var service = new SessionService();
            var session = service.Create(options);
            return session;
        }

    }
}

