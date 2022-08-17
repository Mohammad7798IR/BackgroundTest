using TestApp.DTOs;
using TestApp.Models;
using TestApp.ImplementsRepository.Interfaces;
using TestApp.Implements.Interface;

namespace TestApp.Implements.Services
{
    public class UserService : IUserService
    {

        #region Fields

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region Method [s]

        public async Task<List<ApplicationUser>> GetAllUsers(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                return await _userRepository.GetAllUsers();
            }
            return null;
        }

        public async Task<bool> SignUp(string key, SignUpDTO signUpDTO)
        {

            if (!string.IsNullOrEmpty(key))
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
            }


            return false;
        }

        #endregion

    }
}
