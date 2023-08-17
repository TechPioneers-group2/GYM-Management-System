using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models;

namespace GYM_Management_System.Models.Interfaces
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
        Task<Client> UpdateClient(int gymid, int clientid, UpdateClientDTO client);

        // Delete Client
        Task DeleteClient(int gmyid, int clientid);

    }
}