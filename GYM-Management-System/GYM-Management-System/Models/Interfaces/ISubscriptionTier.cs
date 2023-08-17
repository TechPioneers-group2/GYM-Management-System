using GYM_Management_System.Models.DTOs;

namespace GYM_Management_System.Models.Interfaces
{
    public interface ISubscriptionTier
    {
        // Create a SubscriptionTier
        Task<SubscriptionTier> Create(PostSubscriptionTierDTO subscriptionTier);

        // GET All SubscriptionTiers
        Task<List<GetSubscriptionTierDTO>> GetAllSubscriptionTier();

        // GET SubscriptionTier By ID
        Task<GetSubscriptionTierDTO> GetSubscriptionTier(int SubscriptionTierid);

        // Update SubscriptionTier 
        Task<UpdateSubscriptionTierDTO> UpdateSubscriptionTier(int SubscriptionTierId, UpdateSubscriptionTierDTO subscriptionTier);

        // Delete SubscriptionTier
        Task DeleteSubscriptionTier(int SubscriptionTierId);


    }
}
