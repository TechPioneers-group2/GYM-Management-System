using GYM_Management_System.Models;
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

        public MethodsController(IAzureBlobStorageService azure, IPaymentService payment)
        {
            _azureBlobStorageService = azure;
            _payment = payment;
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

        // implement a behind the scene method to query the clients if any of them is close
    }
}
