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

        private readonly IEmail _email;

        /// <summary>
        /// Initializes a new instance of the <see cref="GymService"/> class.
        /// </summary>
        /// <param name="gymDbContext">The Gym Database context.</param>
        /// <param name="supTier">The subscription tier.</param>
        /// <param name="client">The client.</param>
        public GymService(GymDbContext gymDbContext, ISubscriptionTier supTier, IClient client, IEmail email)
        {
            _gymDbContext = gymDbContext;
            _email = email;
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
                Notification = gym.Notification,
                imageURL = gym.imageURL
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
                Notification = gym.Notification,
                imageURL = gym.imageURL
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
            try
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
                            Price = x.Supplements.Price,
                            Description = x.Supplements.Description,
                            imageURL = x.Supplements.imageURL
                        }
                    })
                    .ToList();

                var eq = await _gymDbContext.GymEquipments
                    .Where(eqid => eqid.GymID == gymid)
                    .Select(eqp => new EquipmentDTO
                    {
                        Name = eqp.Name,
                        Quantity = eqp.Quantity,
                        OutOfService = eqp.OutOfService,
                        GymEquipmentID = eqp.GymEquipmentID,
                        PhotoUrl = eqp.PhotoUrl,
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
                        imageURL = Gm.imageURL
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new GetUserGymDTO();
            }
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
                    imageURL = Gm.imageURL,
                    Equipments = Gm.GymEquipments
                    .Where(eqid => eqid.GymID == Gm.GymID)
                    .Select(geq => new EquipmentDTO
                    {
                        GymEquipmentID = geq.GymEquipmentID,
                        Name = geq.Name,
                        OutOfService = geq.OutOfService,
                        Quantity = geq.Quantity,
                    }).ToList(),
                    clients = Gm.Clients.Select(cl => new PostClientDTO
                    {
                        Name = cl.Name,
                        GymID = cl.GymID,
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
                            Price = x.Supplements.Price,
                            Description = x.Supplements.Description,
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
            try
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
                        imageURL = Gm.imageURL,
                        Equipments = Gm.GymEquipments
                        .Where(eqid => eqid.GymID == Gm.GymID)
                        .Select(geq => new EquipmentDTO()
                        {
                            GymEquipmentID = geq.GymEquipmentID,
                            Name = geq.Name,
                            OutOfService = geq.OutOfService,
                            Quantity = geq.Quantity,
                            PhotoUrl= geq.PhotoUrl
                        }).ToList(),
                        Supplements = Gm.GymSupplements.Select(GS => new GymSupplementDTO()
                        {
                            Quantity = GS.Quantity,
                            SupplementID = GS.SupplementID,
                            Supplements = new GetGymSupplementDTO
                            {
                                Name = GS.Supplements.Name,
                                Price = GS.Supplements.Price,
                                Description = GS.Supplements.Description,
                            }
                        }).ToList(),
                        CurrentCapacity = _gymDbContext.Clients.Count(x => x.GymID == Gm.GymID && x.InGym == true),
                        SubscriptionTier = suppTierList
                            .Select(suppTier => new GymGetSubscriptionTierDTO()
                            {
                                Name = suppTier.Name,
                                Price = suppTier.Price
                            }).ToList()
                    }).ToListAsync();

                return returnVar;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<GetUserGymDTO>();
            }
        }


        /// <summary>
        /// Updates a Gym by ID.
        /// </summary>
        /// <param name="gymid">The ID of the Gym to update.</param>
        /// <param name="updatedGym">The updated Gym data.</param>
        /// <returns>The updated Gym data.</returns>
        public async Task<PutGymDTO> UpdateGym(int gymid, PutGymDTO updatedGym)
        {
            var notificationStatus = updatedGym.Notification;

            Gym currentGym = await _gymDbContext.Gyms.FindAsync(gymid);

            if (currentGym.Notification != notificationStatus)
            {
                var clients = _gymDbContext.Clients
                    .Where(gym => gym.GymID == gymid)
                    .Select(client => client.UserId)
                    .ToList();

                var employees = _gymDbContext.Employees
                    .Where(gym => gym.GymID == gymid)
                    .Select(client => client.UserId)
                    .ToList();

                var users = _gymDbContext.Users
                    .Where(user => employees.Contains(user.Id) || clients.Contains(user.Id))
                    .ToList();


                foreach (var user in users)
                {
                    await _email.SendEmail(user.Email, user.UserName, "Notification From " + currentGym, updatedGym.Notification);
                }
            }

            if (currentGym != null)
            {
                currentGym.Address = updatedGym.Address;
                currentGym.MaxCapacity = updatedGym.MaxCapacity;
                currentGym.CurrentCapacity = updatedGym.CurrentCapacity;
                currentGym.ActiveHours = updatedGym.ActiveHours;
                currentGym.Notification = updatedGym.Notification;
                currentGym.imageURL = updatedGym.imageURL;
                _gymDbContext.Entry(currentGym).State = EntityState.Modified;
                await _gymDbContext.SaveChangesAsync();

                PutGymDTO getGymDTO = new PutGymDTO()
                {
                    Address = updatedGym.Address,
                    MaxCapacity = updatedGym.MaxCapacity,
                    CurrentCapacity = updatedGym.CurrentCapacity,
                    ActiveHours = updatedGym.ActiveHours,
                    Notification = updatedGym.Notification,
                    imageURL = updatedGym.imageURL
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

        //public async Task<GetSupplementFromGymDTO> GetSupplementFromGym(int supplemendid, int gymid)
        //{
        //    var sup = await _gymDbContext.Gyms.Select(x => new GetSupplementFromGymDTO()
        //    {
        //        Qantity=x.Q
        //    });
        //}
    }
}
