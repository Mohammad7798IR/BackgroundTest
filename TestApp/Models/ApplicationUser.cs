using Microsoft.AspNetCore.Identity;

namespace TestApp.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;


        public ICollection<ApplicationUserRole>? UserRoles { get; set; } = new HashSet<ApplicationUserRole>();
    }
}
