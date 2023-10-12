using System.ComponentModel.DataAnnotations;

namespace GYM_Management_System.Models
{
    public class Supplement
    {
        public int SupplementID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Description { get; set; }
        // Navigation props
        public List<GymSupplement>? GymSupplements { get; set; }

    }
}
