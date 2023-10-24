using GYM_Management_System.Data;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GYM_Management_System.Models.Services

{
    /// <summary>
    /// Service for managing gym equipment-related operations in the gym management system.
    /// </summary>
    public class GymEquipmentsService : IGymEquipment
    {
        private readonly GymDbContext _gymDbContext;
        private readonly IAzureBlobStorageService _blobStorageService;


        /// <summary>
        /// Initializes a new instance of the <see cref="GymEquipmentsService"/> class.
        /// </summary>
        /// <param name="gymDbContext">The database context.</param>
        public GymEquipmentsService(GymDbContext gymDbContext, IAzureBlobStorageService photo)
        {
            _gymDbContext = gymDbContext;
            _blobStorageService = photo;
        }

        /// <summary>
        /// Creates a new gym equipment.
        /// </summary>
        /// <param name="equipmentDTO">The gym equipment data to create.</param>
        /// <returns>The created gym equipment data.</returns>
        public async Task<EquipmentDTO> Create(CreatEquipmentDTO equipmentDTO)
        {
            var newEquipment = new GymEquipment()
            {
                Quantity = equipmentDTO.Quantity,
                Name = equipmentDTO.Name,
                OutOfService = equipmentDTO.OutOfService,
                GymID = equipmentDTO.GymID,
                PhotoUrl = equipmentDTO.PhotoUrl,
            };

            await _gymDbContext.GymEquipments.AddAsync(newEquipment);
            await _gymDbContext.SaveChangesAsync();

            var equipmentDtoResult = new EquipmentDTO()
            {
                GymEquipmentID = newEquipment.GymEquipmentID,
                Quantity = newEquipment.Quantity,
                Name = newEquipment.Name,
                OutOfService = newEquipment.OutOfService,
                GymID = newEquipment.GymID,
                PhotoUrl = newEquipment.PhotoUrl,
            };

            return equipmentDtoResult;
        }

        /// <summary>
        /// Deletes gym equipment by ID.
        /// </summary>
        /// <param name="GymEquipmentID">The ID of the gym equipment to delete.</param>
        /// <returns>An asynchronous task.</returns>
        public async Task DeleteGymEquipment(int GymEquipmentID)
        {
            var deletedEquipment = await _gymDbContext.GymEquipments.FindAsync(GymEquipmentID);
            if (deletedEquipment != null)
            {
                _gymDbContext.GymEquipments.Remove(deletedEquipment);
                await _gymDbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Retrieves gym equipment by its ID.
        /// </summary>
        /// <param name="GymEquipmentID">The ID of the gym equipment to retrieve.</param>
        /// <returns>The gym equipment data.</returns>
        public async Task<EquipmentDTO> GetEquipmentById(int GymEquipmentID)
        {
            var Equipment = await _gymDbContext.GymEquipments.Select(E => new EquipmentDTO
            {
                GymEquipmentID = E.GymEquipmentID,
                Quantity = E.Quantity,
                Name = E.Name,
                OutOfService = E.OutOfService,
                GymID = E.GymID,
                PhotoUrl = E.PhotoUrl
            }).FirstOrDefaultAsync(e => e.GymEquipmentID == GymEquipmentID);

            return Equipment;
        }

        /// <summary>
        /// Retrieves a list of all gym equipment.
        /// </summary>
        /// <returns>A list of gym equipment data.</returns>
        public async Task<List<EquipmentDTO>> GetGymEquipments()
        {
            var allEquipment = await _gymDbContext.GymEquipments.Select(E => new EquipmentDTO
            {
                GymEquipmentID = E.GymEquipmentID,
                Quantity = E.Quantity,
                Name = E.Name,
                OutOfService = E.OutOfService,
                GymID = E.GymID,
                PhotoUrl = E.PhotoUrl
            }).ToListAsync();

            return allEquipment;
        }

        /// <summary>
        /// Updates gym equipment data by its ID.
        /// </summary>
        /// <param name="GymEquipmentID">The ID of the gym equipment to update.</param>
        /// <param name="equipmentDTO">The updated gym equipment data.</param>
        /// <returns>The updated gym equipment data.</returns>
        public async Task<EquipmentDTO> UpdateGymEquipment(int GymEquipmentID, EquipmentDTOPutservice equipmentDTO)
        {
            var Selected = await _gymDbContext.GymEquipments.FindAsync(GymEquipmentID);

            if (equipmentDTO.PhotoUrl == null)
            {
                equipmentDTO.PhotoUrl = Selected.PhotoUrl;
            }

            if (Selected != null)
            {
                Selected.Quantity = equipmentDTO.Quantity;
                Selected.OutOfService = equipmentDTO.OutOfService;
                Selected.PhotoUrl = equipmentDTO.PhotoUrl;

                _gymDbContext.Entry(Selected).State = EntityState.Modified;
                await _gymDbContext.SaveChangesAsync();

                var equipmentDtoResult = new EquipmentDTO()
                {
                    GymEquipmentID = Selected.GymEquipmentID,
                    Quantity = Selected.Quantity,
                    Name = Selected.Name,
                    OutOfService = Selected.OutOfService,
                    GymID = Selected.GymID,
                    PhotoUrl = Selected.PhotoUrl,

                };

                return equipmentDtoResult;
            }
            return null;
        }
    }
}
