using gym_management_system.Models.Models.DTOs;

namespace gym_management_system.Models.Models.Interfaces
{
    public interface ISubscriptionTier
    {
        // Create a SubscriptionTier
        Task<PostSubscriptionTierDTO> Create(CreatSubscriptionTierDTO subscriptionTier);

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
