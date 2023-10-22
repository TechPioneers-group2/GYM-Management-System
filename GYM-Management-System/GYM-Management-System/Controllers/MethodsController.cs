using GYM_Management_System.Models;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace GYM_Management_System.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MethodsController : ControllerBase
    {
        private readonly IAzureBlobStorageService _azureBlobStorageService;
        private readonly IPaymentService _payment;
        private readonly IEmail _email;

        private readonly SubscriptionTiersController _subscriptionTiersController;

        public MethodsController(IAzureBlobStorageService azure, IPaymentService payment, SubscriptionTiersController c, IEmail email)
        {
            _subscriptionTiersController = c;
            _azureBlobStorageService = azure;
            _payment = payment;
            _email = email;
        }

        public async Task<string> AddImageToCloudBackEnd(IFormFile file)
        {
            var x = await _azureBlobStorageService.UploadAsync(file);

            return x;
        }

        public async Task<Session> PaymentBackEnd(List<CartViewModel> carts)
        {
            var session = await _payment.PaymentProcess(carts);

            return session;

        }

        public async Task<Session> SubTierPaymentBackEnd(RegisterClientDTO client)
        {
            var actionResult = await _subscriptionTiersController.GetSubscriptionTierBackEnd(client.SubscriptionTierID);

            if (actionResult.Result is OkObjectResult okObjectResult)
            {
                var subTier = okObjectResult.Value as GetSubscriptionTierDTO;
                var session = await _payment.SubTierPaymentProcess(subTier);
                return session;
            }
            else if (actionResult.Result is OkResult)
            {
                // Handle the case where there's no value
                Console.WriteLine("Received OkResult with no value.");
            }
            else
            {
                // Handle other types of results
                Console.WriteLine($"Unexpected result type: {actionResult.Result.GetType().Name}");
            }


            return new Session();
        }

        public async Task RecieveEmail(string senderEmail, string senderName, string emailSubject, string emailBody)
        {
            await _email.RecieveEmail(senderEmail, senderName, emailSubject, emailBody);
        }
    }
}
