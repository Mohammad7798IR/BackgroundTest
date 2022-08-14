using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TestApp.Models;
using TestApp.DTOs;
using TestApp.Service;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp(SignUpDTO signUpDTO)
        {

            if (await _userService.SignUp(signUpDTO))
            {
                return Ok();
            }

            return Conflict();
        }
    }
}
