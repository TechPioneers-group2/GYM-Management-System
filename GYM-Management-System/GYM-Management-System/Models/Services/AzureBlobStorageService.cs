using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using GYM_Management_System.Models.Interfaces;

namespace GYM_Management_System.Models.Services
{
    public class AzureBlobStorageService : IAzureBlobStorageService
    {
        private readonly IConfiguration _configuration;

        private readonly string connStringAzureImageUpload = "DefaultEndpointsProtocol=https;AccountName=techpioneers;AccountKey=J4m4vE7z9QAO/OU44MS9/OfYHWxiRNeMNgt/vqVM6qEVcofZr64EtTUDTcF+e+VOiv0+qEuYkmr3+AStCEXxVg==;EndpointSuffix=core.windows.net";
        public AzureBlobStorageService(IConfiguration configuration)
        {

            _configuration = configuration;

        }
        public async Task<string> UploadAsync(IFormFile file)
        {


            BlobContainerClient blobContainerClient =
                 new BlobContainerClient(connStringAzureImageUpload, "images");
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

            return blobClient.Uri.ToString();

        }
    }
}
