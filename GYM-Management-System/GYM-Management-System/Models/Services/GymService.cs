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


        public GymService(GymDbContext gymDbContext, ISubscriptionTier supTier, IClient client)
        {
            _gymDbContext = gymDbContext;
            _tier = supTier;
        }



        public async Task<PostGymDTO> CreateGym(PostGymDTO gym)
        {
            var newGym = new Gym()
            {
                Name = gym.Name,
                Address = gym.Address,
                CurrentCapacity = gym.CurrentCapacity,
                MaxCapacity = gym.MaxCapacity,
                ActiveHours = gym.ActiveHours,
                Notification = gym.Notification
            };

            _gymDbContext.Gyms.AddAsync(newGym);
            await _gymDbContext.SaveChangesAsync();

            PostGymDTO postGymDTO = new PostGymDTO()
            {
                Name = gym.Name,
                Address = gym.Address,
                CurrentCapacity = gym.CurrentCapacity,
                MaxCapacity = gym.MaxCapacity,
                ActiveHours = gym.ActiveHours,
                Notification = gym.Notification
            };
            return postGymDTO;
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

            var gymSupplements = _gymDbContext.GymSupplements
                    .Include(x => x.Supplements)
                    .Where(x => x.GymID == gymid)
                    .Select(x => new GymSupplementDTO
                    {
                        GymID = x.GymID,
                        Quantity = x.Quantity,
                        SupplementID = x.SupplementID,
                        Supplements = new GetGymSupplementDTO
                        {
                            Name = x.Supplements.Name,
                            Price = x.Supplements.Price
                        }
                    })
                    .ToList();



            var eq = await _gymDbContext.GymEquipments
                .Select(eqp => new EquipmentDTOPut
                {
                    Name = eqp.Name,
                    Quantity = eqp.Quantity,
                    OutOfService = eqp.OutOfService,
                    GymEquipmentID = eqp.GymEquipmentID,
                }).ToListAsync();


            var suppTierList = await _gymDbContext.SubscriptionTiers
            .Select(suppTier => new GymGetSubscriptionTierDTO
            {
                Name = suppTier.Name,
                Price = suppTier.Price
            }).ToListAsync();

            var returnVar = await _gymDbContext.Gyms
                .Select(Gm => new GetUserGymDTO
                {
                    GymID = Gm.GymID,
                    Name = Gm.Name,
                    Address = Gm.Address,
                    CurrentCapacity = _gymDbContext.Clients.Count(x => x.GymID == Gm.GymID && x.InGym == true),
                    MaxCapacity = Gm.MaxCapacity,
                    ActiveHours = Gm.ActiveHours,
                    Notification = Gm.Notification,
                }).FirstOrDefaultAsync(gm => gm.GymID == gymid);

            if (returnVar == null)
            {
                return null;
            }
            returnVar.SubscriptionTier = suppTierList;
            returnVar.Equipments = eq;
            returnVar.Supplements = gymSupplements;
            return returnVar;
        }

        public async Task<List<GetManagerGymDTO>> GetGymManger()
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
                        Name = cl.Name,
                        ClientID = cl.ClientID,
                        InGym = cl.InGym,
                        SubscriptionDate = cl.SubscriptionDate,
                        SubscriptionExpiry = cl.SubscriptionExpiry,
                        SubscriptionTierID = cl.SubscriptionTierID
                    }).ToList(),
                    employees = Gm.Employees.Select(em => new GetEmployeesByGymId()
                    {
                        Name = em.Name,
                        EmployeeID = em.EmployeeID,
                        Salary = em.Salary,
                        JobDescription = em.JobDescription,
                        IsAvailable = em.IsAvailable,
                        WorkingDays = em.WorkingDays,
                        WorkingHours = em.WorkingHours
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
                    //--- adding the GymSupplementDTO
                    Supplements = Gm.GymSupplements.Select(GS => new GymSupplementDTO()
                    {

                        GymID = GS.GymID,
                        Quantity = GS.Quantity,
                        SupplementID = GS.SupplementID,
                        Supplements = new GetGymSupplementDTO
                        {
                            Name = GS.Supplements.Name,
                            Price = GS.Supplements.Price
                        }
                    }).ToList()
                    //------
                }).ToListAsync();

            foreach (var gym in returnVar)
            {

                gym.CurrentCapacity = _gymDbContext.Clients
               .Count(x => x.GymID == gym.GymID && x.InGym == true);


                gym.SubscriptionTier = suppTierList
                .Select(suppTier => new GymGetSubscriptionTierDTO
                {
                    Name = suppTier.Name,
                    Price = suppTier.Price
                }).ToList();
            }

            return returnVar;
        }



        public async Task<PutGymDTO> UpdateGym(int gymid, PutGymDTO updatedGym)
        {
            Gym currentGym = await _gymDbContext.Gyms.FindAsync(gymid);

            if (currentGym != null)
            {
                currentGym.Address = updatedGym.Address;
                currentGym.MaxCapacity = updatedGym.MaxCapacity;
                currentGym.CurrentCapacity = updatedGym.CurrentCapacity;
                currentGym.ActiveHours = updatedGym.ActiveHours;
                currentGym.Notification = updatedGym.Notification;
                _gymDbContext.Entry(currentGym).State = EntityState.Modified;
                await _gymDbContext.SaveChangesAsync();

                PutGymDTO getGymDTO = new PutGymDTO()
                {
                    Address = updatedGym.Address,
                    MaxCapacity = updatedGym.MaxCapacity,
                    CurrentCapacity = updatedGym.CurrentCapacity,
                    ActiveHours = updatedGym.ActiveHours,
                    Notification = updatedGym.Notification,
                };
                return getGymDTO;
            }
            return null;
        }

        public async Task AddSupplementToGym(int gymId, int supplementId, int quantity)
        {
            GymSupplement newGymSupplement = new GymSupplement()
            {
                GymID = gymId,
                SupplementID = supplementId,
                Quantity = quantity,
            };
            _gymDbContext.Entry(newGymSupplement).State = EntityState.Added;
            await _gymDbContext.SaveChangesAsync();
        }
        public async Task<GymSupplement> UpdateSupplementForGym(int gymId, int supplementId, UpdateGymSupplementDTO updateGymSupplement)
        {
            var supplementValue = await _gymDbContext.GymSupplements.FindAsync(gymId, supplementId);

            if (supplementValue != null)
            {
                supplementValue.Quantity = updateGymSupplement.Quantity;
                _gymDbContext.Entry(supplementValue).State = EntityState.Modified;

                await _gymDbContext.SaveChangesAsync();

            }
            return supplementValue;
        }
        public async Task RemoveSupplementFromGym(int gymId, int supplementId)
        {
            var removedSupplement = await _gymDbContext.GymSupplements
                                      .FirstOrDefaultAsync(x => x.GymID == gymId && x.SupplementID == supplementId);

            if (removedSupplement != null)
            {
                _gymDbContext.GymSupplements.Remove(removedSupplement);
                await _gymDbContext.SaveChangesAsync();
            }
        }
    }
}