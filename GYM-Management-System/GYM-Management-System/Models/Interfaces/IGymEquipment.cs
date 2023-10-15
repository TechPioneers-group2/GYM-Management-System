using gym_management_system_front_end.Models.Models.DTOs;

namespace gym_management_system_front_end.Models.Models.Interfaces
{
    public interface IGymEquipment
    {
        // Create a GymEquipment
        Task<EquipmentDTO> Create(CreatEquipmentDTO equipmentDTO);

        // GET All GymEquipments
        Task<List<EquipmentDTO>> GetGymEquipments();

        // GET GymEquipment By ID
        Task<EquipmentDTO> GetEquipmentById(int GymEquipmentID);

        // Update GymEquipment Data
        Task<EquipmentDTO> UpdateGymEquipment(int GymEquipmentID, EquipmentDTOPutservice equipmentDTO);

        // Delete GymEquipment
        Task DeleteGymEquipment(int GymEquipmentID);
    }
}
