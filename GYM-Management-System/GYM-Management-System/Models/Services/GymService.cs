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
            if (deletedGym != null)
            {
                _gymDbContext.Gyms.Remove(deletedGym);
                await _gymDbContext.SaveChangesAsync();
            }
        }

        public async Task<GymDTO> GetGym(int gymid)
        {
            return await _gymDbContext.Gyms
                .Select(Gm => new GymDTO
                {
                    GymID = Gm.GymID,
                    Name = Gm.Name,
                    Address = Gm.Address,
                    CurrentCapacity = Gm.CurrentCapacity,
                    MaxCapacity = Gm.MaxCapacity,
                    ActiveHours = Gm.ActiveHours,
                    Notification = Gm.Notification
                }).FirstOrDefaultAsync(gm => gm.GymID == gymid);
        }

        public async Task<List<GymDTO>> GetGyms()
        {
            return await _gymDbContext.Gyms
                .Select(Gm => new GymDTO
                {
                    GymID = Gm.GymID,
                    Name = Gm.Name,
                    Address = Gm.Address,
                    CurrentCapacity = Gm.CurrentCapacity,
                    MaxCapacity = Gm.MaxCapacity,
                    ActiveHours = Gm.ActiveHours,
                    Notification = Gm.Notification
                }).ToListAsync();
        }

        public async Task<Gym> UpdateGym(int gymid, GymDTO updatedGym)
        {
            var currentGym = await _gymDbContext.Gyms.FindAsync(gymid);

            if (currentGym != null)
            {
                currentGym.Name = updatedGym.Name;
                currentGym.Address = updatedGym.Address;
                currentGym.MaxCapacity = updatedGym.MaxCapacity;
                currentGym.CurrentCapacity = updatedGym.CurrentCapacity;
                currentGym.ActiveHours = updatedGym.ActiveHours;
                currentGym.Notification = updatedGym.Notification;
                _gymDbContext.Entry(currentGym).State = EntityState.Modified;
                await _gymDbContext.SaveChangesAsync();
            }

            return currentGym;
        }
    }
}
