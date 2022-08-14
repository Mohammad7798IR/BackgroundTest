using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestApp.Models;

namespace TestApp.Context
{
    public class TestDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string,
        IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {

        public TestDbContext(DbContextOptions<TestDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }





        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<ApplicationUser>()
                .HasData(new List<ApplicationUser>()
                {
                    new ApplicationUser()
                    {
                       Id ="1" ,
                       Email = "hi@example.com",
                       NormalizedEmail = "HI@EXAMPLE.COM",
                       UserName = "Owner",
                       NormalizedUserName = "OWNER",
                       PhoneNumber = "+111111111111",
                       EmailConfirmed = true,
                       PhoneNumberConfirmed = true,
                       SecurityStamp = Guid.NewGuid().ToString("D"),
                       AccessFailedCount = 1,
                       CreatedAt = DateTime.Now,
                       UserRoles = null,
                       TwoFactorEnabled = false,
                       PasswordHash ="string1",
                       ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                       LockoutEnabled = false,
                       LockoutEnd = DateTime.Now,
                    },
                    new ApplicationUser()
                    {
                       Id ="2" ,
                       Email = "hello@example.com",
                       NormalizedEmail = "HELLO@EXAMPLE.COM",
                       UserName = "Owner",
                       NormalizedUserName = "OWNER",
                       PhoneNumber = "+111111111111",
                       EmailConfirmed = true,
                       PhoneNumberConfirmed = true,
                       SecurityStamp = Guid.NewGuid().ToString("D"),
                       AccessFailedCount = 1,
                       CreatedAt = DateTime.Now,
                       UserRoles = null,
                       TwoFactorEnabled = false,
                       PasswordHash ="string1",
                       ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                       LockoutEnabled = false,
                       LockoutEnd = DateTime.Now,
                    }
                });


            #region IgnoredTables


            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();
            builder.Ignore<IdentityUserToken<string>>();


            #endregion
        }
    }
}
