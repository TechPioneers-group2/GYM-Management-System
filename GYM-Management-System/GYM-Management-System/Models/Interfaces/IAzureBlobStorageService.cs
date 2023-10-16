using GYM_Management_System.Models.DTOs;

namespace GYM_Management_System.Models.Interfaces
{
    public interface IAzureBlobStorageService
    {
        Task<CreatEquipmentDTO> UploadAsync(IFormFile file , CreatEquipmentDTO gymEquipment);

        Task<EquipmentDTOPutservice> UploadAsync(IFormFile file, EquipmentDTOPutservice gymEquipment);
    }
}
