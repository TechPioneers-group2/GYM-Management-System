using GYM_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GYM_Management_System.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MethodsController : ControllerBase
    {
        private readonly IAzureBlobStorageService _azureBlobStorageService;

        public MethodsController(IAzureBlobStorageService azure)
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
