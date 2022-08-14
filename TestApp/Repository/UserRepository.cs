using Microsoft.EntityFrameworkCore;
using TestApp.Context;
using TestApp.Models;

namespace TestApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TestDbContext _context;

        public UserRepository(TestDbContext context)
        {
            _context = context;
        }

        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            return await _context.Users.Where(a => DateTime.Now.Minute - a.CreatedAt.Minute > 1).ToListAsync();
        }


        public void UpdateUser(ApplicationUser user)
        {
            _context.Users.Update(user);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
