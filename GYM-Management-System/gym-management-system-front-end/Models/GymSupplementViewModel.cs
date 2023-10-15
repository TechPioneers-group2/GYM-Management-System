using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace gym_management_system_front_end.Models
{
    public class GymSupplementViewModel
    {
        [DisplayName("Supplement ID ")]
        public int SupplementID { get; set; }
        public int GymID { get; set; }
        [Required]
        public int Quantity { get; set; }


        public SupplementViewModel? Supplement { get; set; }
    }
    public class UpdateGymSupplementDTO
    {
        public int Quantity { get; set; }

        public static explicit operator UpdateGymSupplementDTO(GymSupplementViewModel value)
        {
            return new UpdateGymSupplementDTO { Quantity = value.Quantity, };
        }
    }
}
