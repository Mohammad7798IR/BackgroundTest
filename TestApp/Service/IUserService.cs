using TestApp.DTOs;
using TestApp.Models;

namespace TestApp.Service
{
    public interface IUserService
    {
        Task<List<ApplicationUser>> GetAllUsers();


        Task<bool> SignUp(SignUpDTO signUpDTO);

        //void UpdateUser(ApplicationUser user);

        //Task SaveChanges();
    }
}
