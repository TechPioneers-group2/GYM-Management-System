using GYM_Management_System.Data;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;

namespace GYM_Management_System.Models.Services
{
    public class ClientService : IClient
    {
        private readonly GymDbContext _context;
        private readonly ISubscriptionTier _subscriptionTier;

        public ClientService(GymDbContext context, ISubscriptionTier subscriptionTier)
        {
            _context = context;
            _subscriptionTier = subscriptionTier;
        }


        public async Task<Client> CreateClient(int gymid, PostClientDTO client)
        {
            var subscriptionTier = await _subscriptionTier.GetSubscriptionTier(client.SubscriptionTierID);

            if (subscriptionTier == null)
            {
                return null;
            }

            var currentDate = DateTime.UtcNow;
            var subscriptionExpiry = currentDate.AddMonths(subscriptionTier.Length);

            var newClient = new Client()
            {
                ClientID = client.ClientID,
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

        public async Task DeleteClient(int gymid, int clientid)
        {
            var DeletedClient = await _context.Clients.FindAsync(gymid, clientid);
            if (DeletedClient != null)
            {
                _context.Clients.Remove(DeletedClient);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<GetClientDTO> GetClient(int clientid, int gymid)
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

                }).FirstOrDefaultAsync(cID => cID.ClientID == clientid && cID.GymID == gymid);
        }

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

        public async Task<GetClientDTO> UpdateClient(int gymid, int clientid, UpdateClientDTO client)
        {
            GetClientDTO returnedClient = new GetClientDTO();
            var currentClient = await _context.Clients.FindAsync(gymid, clientid);
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
