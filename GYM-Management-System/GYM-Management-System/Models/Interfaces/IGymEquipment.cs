using GYM_Management_System.Models.DTOs;

namespace GYM_Management_System.Models.Interfaces
{
    public interface IGymEquipment
    {
        // Create a GymEquipment
        Task<GymEquipment> Create (EquipmentDTO equipmentDTO);

        // GET All GymEquipments
        Task<List<EquipmentDTO>> GetGymEquipments();
        // GET GymEquipment By ID
        Task<EquipmentDTO> GetEquipmentById(int GymEquipmentID);
        // Update GymEquipment Data
        Task<GymEquipment> UpdateGymEquipment (int GymEquipmentID , EquipmentDTOPut equipmentDTO);
        // Delete GymEquipment

        Task DeleteGymEquipment (int GymEquipmentID);
    }
}
