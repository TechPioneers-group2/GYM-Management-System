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
        private readonly ISubscriptionTier _tier;
        private readonly IClient _client;

        public GymService(GymDbContext gymDbContext, ISubscriptionTier supTier, IClient client)
        {
            _gymDbContext = gymDbContext;
            _tier = supTier;
            _client = client;
        }

        

        public async Task<Gym> CreateGym(PostGymDTO gym)
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

        
        public async Task<GetUserGymDTO> GetGym(int gymid)
        {
            var suppTierList = await  _gymDbContext.SubscriptionTiers.ToListAsync();
            var supptierDTO = new List<GymGetSubscriptionTierDTO>();
            foreach (var suppTier in suppTierList)
            {
                GymGetSubscriptionTierDTO ggstDTO = new GymGetSubscriptionTierDTO() 
                {
                    Name = suppTier.Name,
                    Price = suppTier.Price
                };
                supptierDTO.Add(ggstDTO);
            }
            var returnVar =  await _gymDbContext.Gyms
                .Select(Gm => new GetUserGymDTO
                {
                    GymID = Gm.GymID,
                    Name = Gm.Name,
                    Address = Gm.Address,
                    CurrentCapacity = _gymDbContext.Clients.Count(x => x.GymID == Gm.GymID && x.InGym == true),
                    MaxCapacity = Gm.MaxCapacity,
                    ActiveHours = Gm.ActiveHours,
                    Notification = Gm.Notification,
                    Equipments = Gm.GymEquipments.Select(geq=> new EquipmentDTOPut() 
                    {
                        GymEquipmentID = geq.GymEquipmentID,
                        Name = geq.Name,
                        OutOfService = geq.OutOfService,
                        Quantity = geq.Quantity,
                    }).ToList(),
                    
                }).FirstOrDefaultAsync(gm => gm.GymID == gymid);
            returnVar.SubscriptionTier = supptierDTO;
            return returnVar;
        }

        public async Task<List<GetManagerGymDTO>> GetGymClient()
        {
            var suppTierList = await _gymDbContext.SubscriptionTiers.ToListAsync();
            var supptierDTO = new List<GymGetSubscriptionTierDTO>();
            foreach (var suppTier in suppTierList)
            {
                GymGetSubscriptionTierDTO ggstDTO = new GymGetSubscriptionTierDTO()
                {
                    Name = suppTier.Name,
                    Price = suppTier.Price
                };
                supptierDTO.Add(ggstDTO);
            }
            var returnVar = await _gymDbContext.Gyms
                .Select(Gm => new GetManagerGymDTO
                {
                    GymID = Gm.GymID,
                    Name = Gm.Name,
                    Address = Gm.Address,
                    CurrentCapacity = Gm.CurrentCapacity,
                    MaxCapacity = Gm.MaxCapacity,
                    ActiveHours = Gm.ActiveHours,
                    Notification = Gm.Notification,
                    Equipments = Gm.GymEquipments.Select(geq => new EquipmentDTOPut()
                    {
                        GymEquipmentID = geq.GymEquipmentID,
                        Name = geq.Name,
                        OutOfService = geq.OutOfService,
                        Quantity = geq.Quantity,
                    }).ToList(),
                    clients = Gm.Clients.Select(cl => new PostClientDTO()
                    {
                       Name=cl.Name,
                       ClientID=cl.ClientID,
                       InGym=cl.InGym,
                       SubscriptionDate=cl.SubscriptionDate,
                       SubscriptionExpiry=cl.SubscriptionExpiry,
                       SubscriptionTierID=cl.SubscriptionTierID
                    } ).ToList(),
                    employees= Gm.Employees.Select(em=> new GetEmployeesByGymId()
                    {
                        Name=em.Name,
                        EmployeeID=em.EmployeeID,
                        Salary=em.Salary,
                        JobDescription=em.JobDescription,
                        IsAvailable=em.IsAvailable,
                        WorkingDays=em.WorkingDays,
                        WorkingHours=em.WorkingHours
                    }).ToList(),
                }).ToListAsync();
            foreach (var gym in returnVar)
            {
                gym.subscriptiontiers = supptierDTO;
            }
            return returnVar;
        }


        public async Task<List<GetUserGymDTO>> GetGyms()
        {
            var suppTierList = await _gymDbContext.SubscriptionTiers.ToListAsync();

            var returnVar = await _gymDbContext.Gyms
                .Select(Gm => new GetUserGymDTO
                {
                    GymID = Gm.GymID,
                    Name = Gm.Name,
                    Address = Gm.Address,
                    MaxCapacity = Gm.MaxCapacity,
                    ActiveHours = Gm.ActiveHours,
                    Notification = Gm.Notification,
                    Equipments = Gm.GymEquipments.Select(geq => new EquipmentDTOPut()
                    {
                        GymEquipmentID = geq.GymEquipmentID,
                        Name = geq.Name,
                        OutOfService = geq.OutOfService,
                        Quantity = geq.Quantity,
                    }).ToList(),
                }).ToListAsync();

            foreach (var gym in returnVar)
            {
                // Calculate the current capacity outside of the query
                gym.CurrentCapacity = _gymDbContext.Clients.Count(x => x.GymID == gym.GymID && x.InGym == true);

                // Set the subscription tier information
                gym.SubscriptionTier = suppTierList.Select(suppTier => new GymGetSubscriptionTierDTO
                {
                    Name = suppTier.Name,
                    Price = suppTier.Price
                }).ToList();
            }

            return returnVar;
        }

        public async Task<Gym> UpdateGym(int gymid, PutGymDTO updatedGym)
        {
            var currentGym = await _gymDbContext.Gyms.FindAsync(gymid);

            if (currentGym != null)
            {
                currentGym.Name = updatedGym.Name;
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
