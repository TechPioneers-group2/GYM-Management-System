using GYM_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IAzureBlobStorageService _azureBlobStorageService;

        public HomeController(IAzureBlobStorageService azure)
        {
            _azureBlobStorageService = azure;
        }

        public async Task<string> AddImageToCloud(IFormFile file)
        {
            var x = await _azureBlobStorageService.UploadAsync(file);

            return x;
        }
    }
}
