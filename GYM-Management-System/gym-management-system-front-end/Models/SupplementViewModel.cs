using System.ComponentModel;

namespace gym_management_system_front_end.Models
{
    public class SupplementViewModel
    {
        [DisplayName("Supplement ID ")]
        public int SupplementID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string? imageURL { get; set; }

    }

    public class SupplementIDDTO
    {
        public int SupplementID { get; set; }
        public string Name { get; set; }

    }
}
