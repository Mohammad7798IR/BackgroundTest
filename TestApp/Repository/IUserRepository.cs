using TestApp.Models;

namespace TestApp.Repository
{
    public interface IUserRepository
    {
        Task<List<ApplicationUser>> GetAllUsers();

        void UpdateUser(ApplicationUser user);

        Task SaveChanges();
    }
}
