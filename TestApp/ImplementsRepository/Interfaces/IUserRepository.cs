using TestApp.Models;


namespace TestApp.ImplementsRepository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<ApplicationUser>> GetAllUsers();

        Task<bool> SignUp(ApplicationUser user);

        Task<bool> UpdateUser(ApplicationUser user);

        Task SaveChanges();
    }
}
