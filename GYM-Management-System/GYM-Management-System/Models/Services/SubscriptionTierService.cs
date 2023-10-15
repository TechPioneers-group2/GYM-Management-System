using gym_management_system.Models.Data;
using gym_management_system.Models.Models.DTOs;
using gym_management_system.Models.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace gym_management_system.Models.Models.Services
{
    /// <summary>
    /// Service class for managing subscription tiers.
    /// </summary>
    public class SubscriptionTierService : ISubscriptionTier
    {
        private readonly GymDbContext _SubscriptionTier;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionTierService"/> class.
        /// </summary>
        /// <param name="SubscriptionTier">The database context for subscription tiers.</param>
        public SubscriptionTierService(GymDbContext SubscriptionTier)
        {
            _SubscriptionTier = SubscriptionTier;
        }

        /// <summary>
        /// Creates a new subscription tier.
        /// </summary>
        /// <param name="subscriptionTier">The subscription tier data to create.</param>
        /// <returns>The created subscription tier data.</returns>
        public async Task<PostSubscriptionTierDTO> Create(CreatSubscriptionTierDTO subscriptionTier)
        {
            var newSubscriptionTier = new SubscriptionTier()
            {
                Name = subscriptionTier.Name,
                Price = subscriptionTier.Price,
                Length = subscriptionTier.Length
            };
            _SubscriptionTier.Add(newSubscriptionTier);
            await _SubscriptionTier.SaveChangesAsync();

            var SubsTierDto = new PostSubscriptionTierDTO()
            {
                SubscriptionTierID = newSubscriptionTier.SubscriptionTierID,
                Name = newSubscriptionTier.Name,
                Price = newSubscriptionTier.Price,
                Length = newSubscriptionTier.Length
            };

            return SubsTierDto;
        }

        /// <summary>
        /// Deletes a subscription tier by ID.
        /// </summary>
        /// <param name="SubscriptionTierId">The ID of the subscription tier to delete.</param>
        public async Task DeleteSubscriptionTier(int SubscriptionTierId)
        {
            var deletedSubscriptionTier = await _SubscriptionTier.SubscriptionTiers.FindAsync(SubscriptionTierId);

            if (deletedSubscriptionTier != null)
            {
                _SubscriptionTier.SubscriptionTiers.Remove(deletedSubscriptionTier);
                await _SubscriptionTier.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Retrieves all subscription tiers.
        /// </summary>
        /// <returns>A list of subscription tiers.</returns>
        public async Task<List<GetSubscriptionTierDTO>> GetAllSubscriptionTier()
        {
            return await _SubscriptionTier.SubscriptionTiers
                .Select(tier => new GetSubscriptionTierDTO
                {
                    SubscriptionTierID = tier.SubscriptionTierID,
                    Name = tier.Name,
                    Price = tier.Price,
                    Length = tier.Length
                }).ToListAsync();
        }

        /// <summary>
        /// Retrieves a subscription tier by ID.
        /// </summary>
        /// <param name="SubscriptionTierid">The ID of the subscription tier to retrieve.</param>
        /// <returns>The subscription tier data.</returns>
        public async Task<GetSubscriptionTierDTO> GetSubscriptionTier(int SubscriptionTierid)
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

        /// <summary>
        /// Updates a subscription tier by ID.
        /// </summary>
        /// <param name="SubscriptionTierId">The ID of the subscription tier to update.</param>
        /// <param name="subscriptionTier">The updated subscription tier data.</param>
        /// <returns>The updated subscription tier data.</returns>
        public async Task<UpdateSubscriptionTierDTO> UpdateSubscriptionTier(int SubscriptionTierId, UpdateSubscriptionTierDTO subscriptionTier)
        {
            var updatedsubtier = await _SubscriptionTier.SubscriptionTiers.FindAsync(SubscriptionTierId);

            if (updatedsubtier != null)
            {
                updatedsubtier.Name = subscriptionTier.Name;
                updatedsubtier.Price = subscriptionTier.Price;
                updatedsubtier.Length = subscriptionTier.Length;
                _SubscriptionTier.Entry(updatedsubtier).State = EntityState.Modified;
                await _SubscriptionTier.SaveChangesAsync();
            }

            return subscriptionTier;
        }
    }
}
