namespace gym_management_system_front_end.Models
{
    public class SubscriptionTiersViewModel
    {
        public int SubscriptionTierID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int Length { get; set; }
    }

    public class GetSubscriptionTierDTO
    {
        public int SubscriptionTierID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int Length { get; set; }
    }

    public class PostSubscriptionTierDTO
    {
        public int SubscriptionTierID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int Length { get; set; }
    }

    public class UpdateSubscriptionTierDTO
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public int Length { get; set; }

    }

    public class GymGetSubscriptionTierDTO
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }

    public class ClientGetSubscriptionTierDTO
    {
        public string Name { get; set; }
    }

    public class ClientUpdateSubscriptionTierDTO
    {
        public int SubscriptionTierID { get; set; }
        public string Name { get; set; }
    }

    public class CreatSubscriptionTierDTO
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public int Length { get; set; }

    }

}
