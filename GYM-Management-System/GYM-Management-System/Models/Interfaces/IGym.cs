using GYM_Management_System.Models.DTOs;

namespace GYM_Management_System.Models.Interfaces
{
    public interface IGym
    {
        // Create a Gym
        Task<Gym> CreateGym(PostGymDTO gym);

        // GET All Gyms
        Task<List<GetUserGymDTO>> GetGyms();


        // GET Gym By ID

        Task<GetUserGymDTO> GetGym(int gymid);

        // Update Gym

        Task<Gym> UpdateGym(int gymid, PutGymDTO updatedGym);

        // Delete Gym

        Task DeleteGym(int gymid);

        Task<List<GetManagerGymDTO>> GetGymClient();




        // Add all supplements in one Gym
        Task AddSupplementToGym(int gymId, int supplementId);

        // Delete all supplements in a Gym
        Task RemoveSupplementFromGym(int gymId, int supplementId);

        // Update all supplements in a Gym
        Task<GymSupplement> UpdateSupplementForGym(int gymId, int supplementId, UpdateGymSupplementDTO updateGymSupplement);

    }
}
