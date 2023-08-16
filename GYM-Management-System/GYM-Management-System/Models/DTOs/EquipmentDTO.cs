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
    public class EquipmentDTOPut
    {
        public int GymEquipmentID { get; set; }
        public string Name { get; set; }
        public int OutOfService { get; set; }
        public int Quantity { get; set; }

        //N.P
    }
}
