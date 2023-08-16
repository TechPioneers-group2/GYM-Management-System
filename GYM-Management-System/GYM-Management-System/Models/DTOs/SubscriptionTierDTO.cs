namespace GYM_Management_System.Models.DTOs
{
    public class GetSubscriptionTierDTO
    {
        public int SubscriptionTierID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }

        public int Length { get; set; }    

        public List<Client>? Clients { get; set; }

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
}
