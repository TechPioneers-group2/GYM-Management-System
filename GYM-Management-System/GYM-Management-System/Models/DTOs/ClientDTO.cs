namespace GYM_Management_System.Models.DTOs
{
    public class PostClientDTO
    {
        public int ClientID { get; set; }
        // Forgein Key
        public int GymID { get; set; }
        // Forgein Key
        public int SubscriptionTierID { get; set; }
        public string Name { get; set; }
        public bool InGym { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public DateTime SubscriptionExpiry { get; set; }
        
        //N.P

    }

    public class GetClientDTO
    {
        // Forgein Key
        public int ClientID { get; set; }

        // Forgein Key
        public int GymID { get; set; }
        public int SubscriptionTierID { get; set; }
        public string Name { get; set; }
        public bool InGym { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public DateTime SubscriptionExpiry { get; set; }

        //N.P
        public ClientGetSubscriptionTierDTO subscriptionTier { get; set; }
    }


    public class UpdateClientDTO
    {
        public int SubscriptionTierID { get; set; }
        public bool InGym { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public DateTime SubscriptionExpiry { get; set; }
    }
    
}
