using gym_management_system_front_end.Models.Models.DTOs;
using gym_management_system_front_end.Models.Models;

namespace gym_management_system_front_end.Models.Models.Interfaces
{
    public interface IClient
    {
        // Create a Client
        Task<Client> CreateClient(int gymid,PostClientDTO client);

        // GET All Clients
        Task<List<GetClientDTO>> GetClients(int gymid);

        // GET Client By ID
        Task<GetClientDTO> GetClient(int clientid, int gymid);

        // Update Client
        Task<GetClientDTO> UpdateClient(int clientid, int gymid, UpdateClientDTO client);

        // Delete Client
        Task DeleteClient(int clientid, int gymid);

    }
}