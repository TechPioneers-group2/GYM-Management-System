using GYM_Management_System.Data;
using GYM_Management_System.Models.DTOs;
using GYM_Management_System.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GYM_Management_System.Models.Services
{
    public class SubscriptionTierService : ISubscriptionTier
    {
        private readonly GymDbContext _SubscriptionTier;

        public SubscriptionTierService(GymDbContext SubscriptionTier)
        {
            _SubscriptionTier = SubscriptionTier;
        }
        public async Task<SubscriptionTier> Create(PostSubscriptionTierDTO subscriptionTier)
        {
            var newSubscriptionTier = new SubscriptionTier()
            {
               SubscriptionTierID = subscriptionTier.SubscriptionTierID,
                Name = subscriptionTier.Name,
                Price = subscriptionTier.Price,
                Length = subscriptionTier.Length
            };
            _SubscriptionTier.Add(newSubscriptionTier);
            await _SubscriptionTier.SaveChangesAsync();
            subscriptionTier.SubscriptionTierID = newSubscriptionTier.SubscriptionTierID; 
            return newSubscriptionTier;
        }

        public async Task DeleteSubscriptionTier(int SubscriptionTierId)
        {
                 var deletedSubscriptionTier =  await
                _SubscriptionTier.SubscriptionTiers.FindAsync(SubscriptionTierId);
            if (deletedSubscriptionTier !=null)
            {
                _SubscriptionTier.SubscriptionTiers.Remove(deletedSubscriptionTier);
                await _SubscriptionTier.SaveChangesAsync();
            }
        }

        public async Task<List<GetSubscriptionTierDTO>> GetAllSubscriptionTier()
        {
            return await _SubscriptionTier.SubscriptionTiers
                .Select(tier => new  GetSubscriptionTierDTO
                {
                    SubscriptionTierID=tier.SubscriptionTierID,
                    Name = tier.Name,
                    Price = tier.Price,
                    Length = tier.Length
                }).ToListAsync();
                   
                
        }

        public async Task<GetSubscriptionTierDTO> GetSubscriptionTier( int SubscriptionTierid)
        {
            return await _SubscriptionTier.SubscriptionTiers
               .Select(tier => new GetSubscriptionTierDTO
               {
                   SubscriptionTierID = tier.SubscriptionTierID,
                   Name = tier.Name,
                   Price = tier.Price,
                   Length = tier.Length

               }).FirstOrDefaultAsync(tr => tr.SubscriptionTierID == SubscriptionTierid);
               
        }

        public async Task<SubscriptionTier> UpdateSubscriptionTier(int SubscriptionTierId, UpdateSubscriptionTierDTO subscriptionTier)
        {
            var updatedsubtier = await _SubscriptionTier.SubscriptionTiers.
                 FindAsync(SubscriptionTierId);

            if (updatedsubtier !=null)
            {
               
                updatedsubtier.Name = subscriptionTier.Name;
                updatedsubtier.Price= subscriptionTier.Price;
                updatedsubtier.Length =subscriptionTier.Length;
                _SubscriptionTier.Entry(updatedsubtier).State= EntityState.Modified;
                await _SubscriptionTier.SaveChangesAsync();
            }

            return updatedsubtier;

        }
    }
}
