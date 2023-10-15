using GYM_Management_System.Models;

namespace gym_management_system.Models
{
    public class SubscriptionTier
    {
        public int SubscriptionTierID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int Length { get; set; }
        public List<Client>? Clients { get; set; }
    }
}
