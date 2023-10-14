using GYM_Management_System.Data;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GYM_Management_System.Models.Services
{
    /// <summary>
    /// Service class for managing Gym operations.
    /// </summary>
    public class GymService : IGym
    {
        private readonly GymDbContext _gymDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="GymService"/> class.
        /// </summary>
        /// <param name="gymDbContext">The Gym Database context.</param>
        /// <param name="supTier">The subscription tier.</param>
        /// <param name="client">The client.</param>
        public GymService(GymDbContext gymDbContext, ISubscriptionTier supTier, IClient client)
        {
            _gymDbContext = gymDbContext;
        }

        /// <summary>
        /// Creates a new Gym.
        /// </summary>
        /// <param name="gym">The Gym data to create.</param>
        /// <returns>The created Gym data.</returns>
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

        /// <summary>
        /// Deletes a Gym by ID.
        /// </summary>
        /// <param name="gymid">The ID of the Gym to delete.</param>
        public async Task DeleteGym(int gymid)
        {
            var deletedGym = await _gymDbContext.Gyms.FindAsync(gymid);
            if (deletedGym != null)
            {
                _gymDbContext.Gyms.Remove(deletedGym);
                await _gymDbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Gets Gym details by ID.
        /// </summary>
        /// <param name="gymid">The ID of the Gym to retrieve.</param>
        /// <returns>The Gym details.</returns>
        public async Task<GetUserGymDTO> GetGym(int gymid)
        {
            var gymSupplements = _gymDbContext.GymSupplements
                .Include(x => x.Supplements)
                .Where(x => x.GymID == gymid)
                .Select(x => new GymSupplementDTO
                {
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

        /// <summary>
        /// Gets the list of Gyms managed by managers.
        /// </summary>
        /// <returns>The list of Gym details for managers.</returns>
        public async Task<List<GetManagerGymDTO>> GetGymManger()
        {
            var suppTierList = await _gymDbContext.SubscriptionTiers.ToListAsync();

            var supptierDTO = suppTierList.Select(suppTier => new GymGetSubscriptionTierDTO
            {
                Name = suppTier.Name,
                Price = suppTier.Price
            }).ToList();

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
                    Equipments = Gm.GymEquipments.Select(geq => new EquipmentDTOPut
                    {
                        GymEquipmentID = geq.GymEquipmentID,
                        Name = geq.Name,
                        OutOfService = geq.OutOfService,
                        Quantity = geq.Quantity,
                    }).ToList(),
                    clients = Gm.Clients.Select(cl => new PostClientDTO
                    {
                        Name = cl.Name,
                        ClientID = cl.ClientID,
                        InGym = cl.InGym,
                        SubscriptionDate = cl.SubscriptionDate,
                        SubscriptionExpiry = cl.SubscriptionExpiry,
                        SubscriptionTierID = cl.SubscriptionTierID
                    }).ToList(),
                    employees = Gm.Employees.Select(em => new GetEmployeesByGymId
                    {
                        Name = em.Name,
                        EmployeeID = em.EmployeeID,
                        Salary = em.Salary,
                        JobDescription = em.JobDescription,
                        IsAvailable = em.IsAvailable,
                        WorkingDays = em.WorkingDays,
                        WorkingHours = em.WorkingHours
                    }).ToList(),
                    Supplements = Gm.GymSupplements.Select(x => new GymSupplementDTO
                    {
                        Quantity = x.Quantity,
                        SupplementID = x.SupplementID,
                        Supplements = new GetGymSupplementDTO
                        {
                            Name = x.Supplements.Name,
                            Price = x.Supplements.Price
                        }
                    }).ToList(),
                    subscriptiontiers = supptierDTO
                }).ToListAsync();

            return returnVar;
        }

        /// <summary>
        /// Gets the list of all Gyms.
        /// </summary>
        /// <returns>The list of Gym details.</returns>
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
                    Supplements = Gm.GymSupplements.Select(GS => new GymSupplementDTO()
                    {
                        Quantity = GS.Quantity,
                        SupplementID = GS.SupplementID,
                        Supplements = new GetGymSupplementDTO
                        {
                            Name = GS.Supplements.Name,
                            Price = GS.Supplements.Price
                        }
                    }).ToList(),
                    CurrentCapacity = _gymDbContext.Clients.Count(x => x.GymID == Gm.GymID && x.InGym == true),
                    SubscriptionTier = suppTierList
                        .Select(suppTier => new GymGetSubscriptionTierDTO
                        {
                            Name = suppTier.Name,
                            Price = suppTier.Price
                        }).ToList()
                }).ToListAsync();

            return returnVar;
        }

        /// <summary>
        /// Updates a Gym by ID.
        /// </summary>
        /// <param name="gymid">The ID of the Gym to update.</param>
        /// <param name="updatedGym">The updated Gym data.</param>
        /// <returns>The updated Gym data.</returns>
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

        /// <summary>
        /// Adds a Supplement to a Gym.
        /// </summary>
        /// <param name="gymId">The ID of the Gym.</param>
        /// <param name="supplementId">The ID of the Supplement to add.</param>
        /// <param name="createdGymSupplement">The Gym Supplement data to create.</param>
        /// <returns>The created Gym Supplement data.</returns>
        public async Task<GymSupplement> AddSupplementToGym(int gymId, int supplementId, UpdateGymSupplementDTO createdGymSupplement)
        {
            GymSupplement newGymSupplement = new GymSupplement()
            {
                GymID = gymId,
                SupplementID = supplementId,
                Quantity = createdGymSupplement.Quantity,
            };
            _gymDbContext.Entry(newGymSupplement).State = EntityState.Added;
            await _gymDbContext.SaveChangesAsync();
            return newGymSupplement;
        }

        /// <summary>
        /// Updates a Supplement for a Gym.
        /// </summary>
        /// <param name="gymId">The ID of the Gym.</param>
        /// <param name="supplementId">The ID of the Supplement to update.</param>
        /// <param name="updateGymSupplement">The updated Gym Supplement data.</param>
        /// <returns>The updated Gym Supplement data.</returns>
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

        /// <summary>
        /// Removes a Supplement from a Gym.
        /// </summary>
        /// <param name="gymId">The ID of the Gym.</param>
        /// <param name="supplementId">The ID of the Supplement to remove.</param>
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
