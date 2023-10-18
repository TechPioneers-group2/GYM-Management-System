namespace GYM_Management_System.Models.DTOs
{
    public class EquipmentDTO
    {
        public int GymEquipmentID { get; set; }
        public int GymID { get; set; }
        public string Name { get; set; }
        public int OutOfService { get; set; }
        public int Quantity { get; set; }
        // public string img { get; set; }
        public string PhotoUrl { get; set; }


    }
    public class CreatEquipmentDTO
    {
        public int GymID { get; set; }
        public string Name { get; set; }
        public int OutOfService { get; set; }
        public int Quantity { get; set; }

        // public string img { get; set; }
        public string? PhotoUrl { get; set; }

        public static explicit operator EquipmentDTOPutservice(CreatEquipmentDTO creatEquipmentDTO)
        {

            return new EquipmentDTOPutservice
            {
                OutOfService = creatEquipmentDTO.OutOfService,
                PhotoUrl = creatEquipmentDTO.PhotoUrl,
                Quantity = creatEquipmentDTO.Quantity,
            };

        }
        public static explicit operator CreatEquipmentDTO(EquipmentDTOPutservice creatEquipmentDTO)
        {

            return new CreatEquipmentDTO
            {
                GymID=0,
                Name="",
                OutOfService = creatEquipmentDTO.OutOfService,
                PhotoUrl = creatEquipmentDTO.PhotoUrl,
                Quantity = creatEquipmentDTO.Quantity,
            };

        }


    }

    public class EquipmentDTOPut
    {
        public int GymEquipmentID { get; set; }
        public string Name { get; set; }
        public int OutOfService { get; set; }
        public int Quantity { get; set; }
        // public string img { get; set; }
        public string? PhotoUrl { get; set; }


    }
    public class EquipmentDTOPutservice
    {
        public int OutOfService { get; set; }
        public int Quantity { get; set; }
        // public string img { get; set; }
        public string? PhotoUrl { get; set; }

    }
}
