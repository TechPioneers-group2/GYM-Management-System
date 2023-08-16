using GYM_Management_System.Models.DTOs;

namespace GYM_Management_System.Models.Interfaces
{
    public interface IGymSupplement
    {
        // Create a Gym Supplement
        Task<PostGymSupplementDTO> CreateGymSupplement(int gymId, int supplementId, PostGymSupplementDTO gymSupplementDTO);

        // GET All Gym Supplements
        Task<List<GetGymSupplementDTO>> GetAllGymSupplements(int gymId);

        // GET Gym Supplement By ID
        Task<GetGymSupplementDTO> GetGymSupplementById(int gymId, int supplementId);

        // Update Gym Supplement Data
        Task<PostGymSupplementDTO> UpdateGymSupplement(int gymId, int supplementId, PostGymSupplementDTO updatedGymSupplementDTO);

        // Delete Gym Supplement
        Task<bool> DeleteGymSupplement(int gymId, int supplementId);
    }
}
