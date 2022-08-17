using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TestApp.DTOs;
using TestApp.Filters;
using TestApp.Implements.Interface;



namespace TestApp.Controllers
{
    //[EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        #region Fields

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion


        #region Method [s]

        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp([FromHeader] string Id, SignUpDTO signUpDTO)
        {

            if (await _userService.SignUp(Id, signUpDTO))
            {
                return Ok();
            }

            return Conflict();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll([FromHeader] string Id)
        {
            return Ok(await _userService.GetAllUsers(Id));
        }

        #endregion

    }
}
