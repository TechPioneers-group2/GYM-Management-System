using System.ComponentModel.DataAnnotations;

namespace GYM_Management_System.Models
{
    public class Supplement
    {
        public int SupplementID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }

        public string? imageURL { get; set; }
        // Navigation props
        public List<GymSupplement>? GymSupplements { get; set; }

    }
}
