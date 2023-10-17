using System.ComponentModel.DataAnnotations;

namespace GYM_Management_System.Models.DTOs
{
    public class GetUserGymDTO
    {
        [Key]
        public int GymID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public string? ActiveHours { get; set; }
        public string? Notification { get; set; }

        //NP

        public List<EquipmentDTO>? Equipments { get; set; }
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

        public List<GymSupplementDTO>? Supplements { get; set; }
        public List<EquipmentDTO> Equipments { get; set; }
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
    }


    public class PutGymDTO
    {
        public string? Address { get; set; }
        public string? MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public string? ActiveHours { get; set; }
        public string? Notification { get; set; }


    }

	public class GymBaseDto
	{
		public int GymID { get; set; }
		public string? Name { get; set; }


	}
}
