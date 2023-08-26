using GYM_Management_System.Models.DTOs;

namespace GYM_Management_System.Models.Interfaces
{
    public interface ISupplement
    {
        // Create a Supplement
        Task<SupplementDTO> CreateSupplement(CreatSupplementDTO supplementDTO);

        // GET All Supplements
        Task<List<SupplementDTO>> GetAllSupplements();

        // GET Supplement By ID
        Task<SupplementDTO> GetSupplementById(int supplementId);

        // Update Supplement Data
        Task<SupplementDTO> UpdateSupplement(int supplementId, CreatSupplementDTO supplement);

        // Delete Supplement
        Task<bool> DeleteSupplement(int supplementId);
    }
}
