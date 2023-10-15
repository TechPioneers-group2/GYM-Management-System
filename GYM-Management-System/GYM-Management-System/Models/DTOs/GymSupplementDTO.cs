namespace gym_management_system_front_end.Models.Models.DTOs
{
    public class GymSupplementDTO
    {
        public int SupplementID { get; set; }
        //public int GymID { get; set; }
        public int Quantity { get; set; }

        // Navigation props
        public GetGymSupplementDTO? Supplements { get; set; }

    }

    public class UpdateGymSupplementDTO
    {
        public int Quantity { get; set; }
    }


}
