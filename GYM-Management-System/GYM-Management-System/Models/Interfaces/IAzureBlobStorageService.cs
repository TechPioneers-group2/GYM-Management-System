namespace GYM_Management_System.Models.Interfaces
{
    public interface IAzureBlobStorageService
    {
        Task<string> UploadAsync(IFormFile file);
    }
}
