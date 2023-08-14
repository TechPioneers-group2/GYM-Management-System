using GYM_Management_System.Models.DTOs;

namespace GYM_Management_System.Models.Interfaces
{
    public interface IGym
    {
        // Create a Gym
        Task<Gym> Create(GymDTO gym);

        // GET All Gyms
        Task<List<GymDTO>> GetGyms();


        // GET Gym By ID

        Task<GymDTO> GetGym(int gymid);

        // Update Gym

        Task<Gym> UpdateGym(int gymid , GymDTO gym);

        // Delete Gym

        Task DeleteGym(int gymid);

    }
}
