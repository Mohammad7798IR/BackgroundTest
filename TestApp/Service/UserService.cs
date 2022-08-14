using TestApp.DTOs;
using TestApp.Models;
using TestApp.Repository;

namespace TestApp.Service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }


        public async Task<bool> SignUp(SignUpDTO signUpDTO)
        {
            var user = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = signUpDTO.Username,
                PasswordHash = signUpDTO.Password,
                EmailConfirmed = false
            };

            if (await _userRepository.SignUp(user))
            {
                await _userRepository.SaveChanges();
                return true;
            }


            return false;
        }
    }
}
