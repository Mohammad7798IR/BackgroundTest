using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TestApp.Models
{
    public class ApplicationRole : IdentityRole<string>
    {
        [Key]
        public string? Id { get; set; }


        public ICollection<ApplicationUserRole> userRoles { get; set; }
    }
}
