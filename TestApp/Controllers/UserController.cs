using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TestApp.DTOs;
using TestApp.Implements.Interface;



namespace TestApp.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        #region Ctor

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion


        #region Method[s]

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

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAllUsers());
        }

        #endregion

    }
}
