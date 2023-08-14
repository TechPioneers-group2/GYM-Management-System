namespace GYM_Management_System.Models
{
    public class SubscriptionTier
    {
        public int SubscriptionTierID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }

        public List<Client>? Clients { get; set; }
    }
}
