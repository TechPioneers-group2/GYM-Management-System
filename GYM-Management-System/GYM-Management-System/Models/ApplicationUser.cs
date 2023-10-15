using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace gym_management_system.Models
{
    public class ApplicationUser : IdentityUser
    {
        [NotMapped]
        public IList<string> Roles { get; set; }
    }
}
