using GYM_Management_System.Data;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;

namespace GYM_Management_System.Models.Services
{

    public class GymService : IGym
    {
        private readonly GymDbContext _gymDbContext;

        public GymService(GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }
        public async Task<Gym> Create(GymDTO gym)
        {
            var newGym = new Gym()
            {
                GymID = gym.GymID,
                Name = gym.Name,
                Address = gym.Address,
                CurrentCapacity = gym.CurrentCapacity,
                MaxCapacity = gym.MaxCapacity,
                ActiveHours = gym.ActiveHours,
                Notification = gym.Notification
            };
            _gymDbContext.Gyms.Add(newGym);
            await _gymDbContext.SaveChangesAsync();
            gym.GymID = newGym.GymID;
            return newGym;
        }

        public async Task DeleteGym(int gymid)
        {
            var deletedGym = await _gymDbContext.Gyms.FindAsync(gymid);
            if (deletedGym !=null)
            {
                _gymDbContext.Gyms.Remove(deletedGym);
                await _gymDbContext.SaveChangesAsync();
            }
        }

        public Task<GymDTO> GetGym(int gymid)
        {
            throw new NotImplementedException();
        }

        public Task<List<GymDTO>> GetGyms()
        {
            throw new NotImplementedException();
        }

        public Task<Gym> UpdateGym(int gymid, GymDTO gym)
        {
            throw new NotImplementedException();
        }
    }
}
