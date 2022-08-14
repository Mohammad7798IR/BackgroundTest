using TestApp.Models;

namespace TestApp.Service
{
    public interface IUserService
    {
        Task<List<ApplicationUser>> GetAllUsers();

        //void UpdateUser(ApplicationUser user);

        //Task SaveChanges();
    }
}
