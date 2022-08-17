using TestApp.DTOs;
using TestApp.Models;

namespace TestApp.Implements.Interface
{
    public interface IUserService
    {
        Task<List<ApplicationUser>> GetAllUsers(string key);


        Task<bool> SignUp(string key, SignUpDTO signUpDTO);

        //void UpdateUser(ApplicationUser user);

        //Task SaveChanges();
    }
}
