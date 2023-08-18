using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace GYM_Management_System.Models
{
    public class ApplicationUser:IdentityUser 
    {
        [NotMapped]
        public IList<string> Roles { get; set; }
    }
}
