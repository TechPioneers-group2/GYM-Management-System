using GYM_Management_System.Models.DTOs;

namespace GYM_Management_System.Models.Interfaces
{
    public interface ISupplement
    {
        // Create a Supplement
        Task<GetSupplementDTO> CreateSupplement(GetSupplementDTO supplementDTO);

        // GET All Supplements
        Task<List<GetSupplementDTO>> GetAllSupplements();

        // GET Supplement By ID
        Task<GetSupplementDTO> GetSupplementById(int supplementId);

        // Update Supplement Data
        Task<GetSupplementDTO> UpdateSupplement(int supplementId, UpdateSupplementDTO updatedSupplementDTO);

        // Delete Supplement
        Task<bool> DeleteSupplement(int supplementId);
    }
}
