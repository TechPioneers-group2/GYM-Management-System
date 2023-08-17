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

        Task<List<GetManagerGymDTO>> GetGymManger();



    }
}
