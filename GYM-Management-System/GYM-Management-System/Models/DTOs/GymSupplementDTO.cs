namespace GYM_Management_System.Models.DTOs
{
    public class GetGymSupplementDTO
    {
        public int SupplementID { get; set; }
        public int GymID { get; set; }
        public int Quantity { get; set; }

        // Navigation props
        public GetGymDTO? Gym { get; set; }
        public GetSupplementDTO? Supplement { get; set; }
    }
    public class PostGymSupplementDTO
    {
        public int SupplementID { get; set; }
        public int GymID { get; set; }
        public int Quantity { get; set; }


    }
}
