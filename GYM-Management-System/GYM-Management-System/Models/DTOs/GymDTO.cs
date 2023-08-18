namespace GYM_Management_System.Models.DTOs
{
    public class GetUserGymDTO
    {
        public int GymID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public string? ActiveHours { get; set; }
        public string? Notification { get; set; }

        //NP

        public List<EquipmentDTOPut>? Equipments { get; set; }
        public List<GymGetSubscriptionTierDTO>? SubscriptionTier { get; set; }
        public List<GymSupplementDTO>? Supplements { get; set; }
    }

    public class GetManagerGymDTO
    {
        public int GymID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public string? ActiveHours { get; set; }
        public string? Notification { get; set; }

        //NP

        public List<EquipmentDTOPut> Equipments { get; set; }
        public List<PostClientDTO> clients { get; set; }
        public List<GetEmployeesByGymId> employees { get; set; }
        public List<GymGetSubscriptionTierDTO> subscriptiontiers { get; set; }
    }

    public class PostGymDTO
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public string? ActiveHours { get; set; }
        public string? Notification { get; set; }


    public class PutGymDTO
    {
       // public string? Name { get; set; }
        public string? MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public string? ActiveHours { get; set; }
        public string? Notification { get; set; }
        //public List<SupplementDTO>? Supplements { get; set; }

    }


}
