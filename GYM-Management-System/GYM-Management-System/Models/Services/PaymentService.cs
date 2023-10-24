using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Stripe;
using Stripe.Checkout;

namespace GYM_Management_System.Models.Services
{
    public class PaymentService : IPaymentService
    {
        /*  public async Task<Session> PaymentProcess(List<CartViewModel> carts)
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
           }*/

        public async Task<Session> SubTierPaymentProcess(GetSubscriptionTierDTO subTier)
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

            string substring = subTier.Price.Split(new char[] { ' ' }, 2)[0];

            int price = int.Parse(substring);

            var sessionLineItem = new SessionLineItemOptions()
            {
                Quantity = 1,

                PriceData = new SessionLineItemPriceDataOptions()
                {
                    UnitAmount = price * 100,
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions()
                    {
                        Name = subTier.Name
                    }
                }
            };
            options.LineItems.Add(sessionLineItem);

            var service = new SessionService();
            var session = service.Create(options);
            return session;
        }

    }
}


