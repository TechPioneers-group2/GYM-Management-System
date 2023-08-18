using GYM_Management_System.Data;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore; // For Entity Framework Core's asynchronous methods
using System.Linq; // For IQueryable and other LINQ-related functionalities

namespace GYM_Management_System.Models.Services
{
    public class GymEquipmentsService : IGymEquipment
    {
        private readonly GymDbContext _gymDbContext;

        public GymEquipmentsService(GymDbContext gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }
        public async Task<EquipmentDTO> Create(CreatEquipmentDTO equipmentDTO)
        {
            var newEquipment = new GymEquipment()
            {
                //GymEquipmentID = equipmentDTO.GymEquipmentID,
                Quantity = equipmentDTO.Quantity,
                Name = equipmentDTO.Name,
                OutOfService = equipmentDTO.OutOfService,
                GymID = equipmentDTO.GymID
            };

            // add the await and Async 
             await _gymDbContext.GymEquipments.AddAsync(newEquipment);
            await _gymDbContext.SaveChangesAsync();
            //equipmentDTO.GymEquipmentID = newEquipment.GymEquipmentID;
            var equipmentDtoResult = new EquipmentDTO()
            {
                GymEquipmentID = newEquipment.GymEquipmentID,
                Quantity = newEquipment.Quantity,
                Name = newEquipment.Name,
                OutOfService = newEquipment.OutOfService,
                GymID = newEquipment.GymID
            };

			return equipmentDtoResult;
        }

        public async Task DeleteGymEquipment(int GymEquipmentID)
        {
            var deletedEquipment = await _gymDbContext.GymEquipments.FindAsync(GymEquipmentID);
            if (deletedEquipment != null)
            {
                _gymDbContext.GymEquipments.Remove(deletedEquipment);
                await _gymDbContext.SaveChangesAsync();

            }
        }
        public async Task<EquipmentDTO> GetEquipmentById(int GymEquipmentID)
        {
            var Equipment = await _gymDbContext.GymEquipments.Select(E => new EquipmentDTO
            {
                GymEquipmentID = E.GymEquipmentID,
                Quantity = E.Quantity,
                Name = E.Name,
                OutOfService = E.OutOfService,
                GymID = E.GymID
            }).FirstOrDefaultAsync(e => e.GymEquipmentID==GymEquipmentID);
            return Equipment;   
        }

        public  async Task<List<EquipmentDTO>> GetGymEquipments()
        {
            var allEquipment = await _gymDbContext.GymEquipments.Select(E => new EquipmentDTO
            {
                GymEquipmentID = E.GymEquipmentID,
                Quantity = E.Quantity,
                Name = E.Name,
                OutOfService = E.OutOfService,
                GymID = E.GymID
            }).ToListAsync();
            return allEquipment;
        }

        public async Task<EquipmentDTO> UpdateGymEquipment(int GymEquipmentID, EquipmentDTOPutservice equipmentDTO)
        {
            var Selected = await _gymDbContext.GymEquipments.FindAsync(GymEquipmentID);
            if (Selected != null)
            {
                Selected.Name = equipmentDTO.Name;
                Selected.Quantity = equipmentDTO.Quantity;
                Selected.OutOfService = equipmentDTO.OutOfService;
              
               _gymDbContext.Entry(Selected).State = EntityState.Modified;
                await _gymDbContext.SaveChangesAsync();
				var equipmentDtoResult = new EquipmentDTO()
				{
					GymEquipmentID = Selected.GymEquipmentID,
					Quantity = Selected.Quantity,
					Name = Selected.Name,
					OutOfService = Selected.OutOfService,
					GymID = Selected.GymID
				};
                return equipmentDtoResult;  
			}
            return null;


        }
    }
}
