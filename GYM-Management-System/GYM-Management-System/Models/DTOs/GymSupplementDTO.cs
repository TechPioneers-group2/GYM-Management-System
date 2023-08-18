namespace GYM_Management_System.Models.DTOs
{
    public class GymSupplementDTO
    {
        public int SupplementID { get; set; }
        public int GymID { get; set; }
        public int Quantity { get; set; }

        public GetGymSupplementDTO? Supplements { get; set; }

    }

	public class UpdateGymSupplementDTO
	{
		public int Quantity { get; set; }
	}

	
}
