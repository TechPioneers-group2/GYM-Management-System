namespace GYM_Management_System.Models.DTOs
{
    public class EquipmentDTO
    {
        public int GymEquipmentID { get; set; }
        public int GymID { get; set; }
        public string Name { get; set; }
        public int OutOfService { get; set; }
        public int Quantity { get; set; }

        //N.P
    }
	public class CreatEquipmentDTO
	{
		//public int GymEquipmentID { get; set; }
		public int GymID { get; set; }
		public string Name { get; set; }
		public int OutOfService { get; set; }
		public int Quantity { get; set; }

		//N.P
	}
    // to use with athor services
	public class EquipmentDTOPut
    {
        public int GymEquipmentID { get; set; }
        public string Name { get; set; }
        public int OutOfService { get; set; }
        public int Quantity { get; set; }

        //N.P
    }
	public class EquipmentDTOPutservice
	{
		//public int GymEquipmentID { get; set; }
		public string Name { get; set; }
		public int OutOfService { get; set; }
		public int Quantity { get; set; }

		//N.P
	}
}
