using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TestApp.Models
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {

        [Key]
        public string? Id { get; set; }


        public ApplicationUser applicationUser { get; set; }


        public ApplicationRole applicationRole { get; set; }
    }
}
