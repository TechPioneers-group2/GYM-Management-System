using GYM_Management_System.Data;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using GYM_Management_System.Models.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GYM_Management_System.Models.Services
{
    /// <summary>
    /// Service for managing client-related operations in the gym management system.
    /// </summary>
    public class ClientService : IClient
    {
        private readonly GymDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientService"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public ClientService(GymDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new client in the gym.
        /// </summary>
        /// <param name="gymid">The ID of the gym.</param>
        /// <param name="client">The client data to create.</param>
        /// <returns>The created client data.</returns>
        public async Task<Client> CreateClient(int gymid, PostClientDTO client)
        {
            var subscriptionTier = await _context.SubscriptionTiers
                .FirstOrDefaultAsync(tr => tr.SubscriptionTierID == client.SubscriptionTierID);

            if (subscriptionTier == null)
            {
                return null;
            }

            var currentDate = DateTime.UtcNow;
            var subscriptionExpiry = currentDate.AddMonths(subscriptionTier.Length);

            var newClient = new Client()
            {
                GymID = gymid,
                SubscriptionTierID = client.SubscriptionTierID,
                Name = client.Name,
                InGym = client.InGym,
                SubscriptionDate = currentDate, // Set the subscription date to today's date
                SubscriptionExpiry = subscriptionExpiry, // Set the calculated expiry date
            };

            _context.Clients.Add(newClient);
            await _context.SaveChangesAsync();
            return newClient;
        }

        /// <summary>
        /// Deletes a client from the gym.
        /// </summary>
        /// <param name="clientid">The ID of the client to delete.</param>
        /// <param name="gymid">The ID of the gym.</param>
        /// <returns>An asynchronous task.</returns>
        public async Task DeleteClient(int clientid, int gymid)
        {
            var DeletedClient = await _context.Clients.FirstOrDefaultAsync(c => c.ClientID == clientid && c.GymID == gymid);
            if (DeletedClient != null)
            {
                _context.Clients.Remove(DeletedClient);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Retrieves a client's data by their ID and gym ID.
        /// </summary>
        /// <param name="clientid">The ID of the client.</param>
        /// <param name="gymid">The ID of the gym.</param>
        /// <returns>The client's data.</returns>
        public async Task<GetClientDTO> GetClient(int clientid, int gymid)
        {
            var newclient = await _context.Clients
                .Select(nc => new GetClientDTO()
                {
                    ClientID = nc.ClientID,
                    GymID = nc.GymID,
                    SubscriptionTierID = nc.SubscriptionTierID,
                    Name = nc.Name,
                    InGym = nc.InGym,
                    SubscriptionDate = nc.SubscriptionDate,
                    SubscriptionExpiry = nc.SubscriptionExpiry,
                    subscriptionTier = new ClientGetSubscriptionTierDTO()
                    {
                        Name = nc.SubscriptionTierOBJ.Name
                    }

                }).FirstOrDefaultAsync(cID => cID.ClientID == clientid && cID.GymID == gymid);

            if (newclient == null)
            {
                return null;
            }

            return newclient;
        }

        /// <summary>
        /// Retrieves a list of clients for a specific gym.
        /// </summary>
        /// <param name="gymid">The ID of the gym.</param>
        /// <returns>A list of clients.</returns>
        public async Task<List<GetClientDTO>> GetClients(int gymid)
        {
            return await _context.Clients
                .Select(nc => new GetClientDTO()
                {
                    ClientID = nc.ClientID,
                    GymID = nc.GymID,
                    SubscriptionTierID = nc.SubscriptionTierID,
                    Name = nc.Name,
                    InGym = nc.InGym,
                    SubscriptionDate = nc.SubscriptionDate,
                    SubscriptionExpiry = nc.SubscriptionExpiry,
                    subscriptionTier = new ClientGetSubscriptionTierDTO()
                    {
                        Name = nc.SubscriptionTierOBJ.Name
                    }
                }).Where(cl => cl.GymID == gymid).ToListAsync();
        }

        /// <summary>
        /// Updates a client's data.
        /// </summary>
        /// <param name="clientid">The ID of the client to update.</param>
        /// <param name="gymid">The ID of the gym.</param>
        /// <param name="client">The updated client data.</param>
        /// <returns>The updated client's data.</returns>
        public async Task<GetClientDTO> UpdateClient(int clientid, int gymid, UpdateClientDTO client)
        {
            GetClientDTO returnedClient = new GetClientDTO();
            var currentClient = await _context.Clients.FirstOrDefaultAsync(c => c.ClientID == clientid && c.GymID == gymid);
            if (currentClient != null)
            {
                currentClient.SubscriptionTierID = client.SubscriptionTierID;
                currentClient.InGym = client.InGym;
                _context.Entry(currentClient).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                returnedClient.ClientID = currentClient.ClientID;
                returnedClient.GymID = currentClient.GymID;
                returnedClient.Name = currentClient.Name;
                returnedClient.SubscriptionDate = currentClient.SubscriptionDate;
                returnedClient.SubscriptionExpiry = currentClient.SubscriptionExpiry;
                returnedClient.SubscriptionTierID = currentClient.SubscriptionTierID;
                returnedClient.InGym = currentClient.InGym;
                var queryST = await _context.SubscriptionTiers.FirstOrDefaultAsync(x => x.SubscriptionTierID == currentClient.SubscriptionTierID);
                returnedClient.subscriptionTier = new ClientGetSubscriptionTierDTO
                {
                    Name = queryST.Name
                };

                return returnedClient;
            }
            return null;
        }
    }
}