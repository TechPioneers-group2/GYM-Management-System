﻿using GYM_Management_System.Models.DTOs;

namespace GYM_Management_System.Models.Interfaces
{
    public interface IGym
    {
        // Create a Gym
        Task<PostGymDTO> CreateGym(PostGymDTO gym);

        // GET All Gyms
        Task<List<GetUserGymDTO>> GetGyms();


        // GET Gym By ID

        Task<GetUserGymDTO> GetGym(int gymid);

        // Update Gym

        Task<PutGymDTO> UpdateGym(int gymid, PutGymDTO updatedGym);

        // Delete Gym

        Task DeleteGym(int gymid);

        Task<List<GetManagerGymDTO>> GetGymManger();




        // Add a supplement to a Gym
        Task AddSupplementToGym(int gymId, int supplementId, int quantity);

        // Delete all supplements in a Gym
        Task RemoveSupplementFromGym(int gymId, int supplementId);

        // Update all supplements in a Gym
        Task<GymSupplement> UpdateSupplementForGym(int gymId, int supplementId, UpdateGymSupplementDTO updateGymSupplement);

    }
}
