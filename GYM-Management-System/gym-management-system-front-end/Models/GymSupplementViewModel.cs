using System.ComponentModel.DataAnnotations;

namespace gym_management_system_front_end.Models
{
    public class GymSupplementViewModel
    {
        public int SupplementID { get; set; }
        public int GymID { get; set; }
        [Required]
        public int Quantity { get; set; }


        public SupplementViewModel? Supplement { get; set; }
    }
}
