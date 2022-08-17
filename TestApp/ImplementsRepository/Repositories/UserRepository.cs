using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestApp.Context;
using TestApp.Models;
using TestApp.ImplementsRepository.Interfaces;

namespace TestApp.ImplementsRepository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TestDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(TestDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> SignUp(ApplicationUser user)
        {
            return (await _userManager.CreateAsync(user, user.PasswordHash)).Succeeded;
        }

        public async Task<bool> UpdateUser(ApplicationUser user)
        {
            return (await _userManager.UpdateAsync(user)).Succeeded;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
