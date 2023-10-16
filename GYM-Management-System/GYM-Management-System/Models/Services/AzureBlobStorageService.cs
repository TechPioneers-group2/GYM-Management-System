using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;

namespace GYM_Management_System.Models.Services
{
    public class AzureBlobStorageService : IAzureBlobStorageService
    {
        private readonly IConfiguration _configuration;
        public AzureBlobStorageService(IConfiguration configuration)
        {

            _configuration = configuration;

        }
        public async Task<CreatEquipmentDTO> UploadAsync(IFormFile file , CreatEquipmentDTO gymEquipment)
        {


            BlobContainerClient blobContainerClient =
                 new BlobContainerClient(_configuration.GetConnectionString("AzureString"), "images");
            await blobContainerClient.CreateIfNotExistsAsync();
            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);

            using var stream = file.OpenReadStream();

            BlobUploadOptions blobUploadOptions = new BlobUploadOptions
            {
                HttpHeaders = new BlobHttpHeaders { ContentType = file.ContentType }
            };

            if (!blobClient.Exists())
            {
                await blobClient.UploadAsync(stream, blobUploadOptions);
            }

            gymEquipment.PhotoUrl= blobClient.Uri.ToString();

            return gymEquipment;
        }

        public async Task<EquipmentDTOPutservice> UploadAsync(IFormFile file, EquipmentDTOPutservice gymEquipment)
        {


            BlobContainerClient blobContainerClient =
                 new BlobContainerClient(_configuration.GetConnectionString("AzureString"), "images");
            await blobContainerClient.CreateIfNotExistsAsync();
            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);

            using var stream = file.OpenReadStream();

            BlobUploadOptions blobUploadOptions = new BlobUploadOptions
            {
                HttpHeaders = new BlobHttpHeaders { ContentType = file.ContentType }
            };

            if (!blobClient.Exists())
            {
                await blobClient.UploadAsync(stream, blobUploadOptions);
            }

            gymEquipment.PhotoUrl = blobClient.Uri.ToString();

            return gymEquipment;
        }
    }
}
