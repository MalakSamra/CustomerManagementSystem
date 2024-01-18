using CustomerManagementSystem.BL;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public ActionResult<List<UserAddReadDto>> GetAllUsers() 
        {
            return _userManager.GetAllUsers().ToList();
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult <UserAddReadDto> GetUserById(string id)
        {
            UserAddReadDto? user = _userManager.GetUserById(id);
            if(user == null)
            {
                return NotFound();
            }
            return user;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register (RegisterDto registerDto)
        {
            var result = await _userManager.Register(registerDto);
            if (result.IsSuccess)
            {
                return Ok(new { message = "User registered successfully" });
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenDto>> Login(LoginDto loginDto)
        {
            TokenDto tokenResult = await _userManager.Login(loginDto);

            if (tokenResult.Result == TokenResult.Failure)
            {
                return Unauthorized();
            }
            else if (tokenResult.Result == TokenResult.UserpasswordError)
            {
                return BadRequest("Invalid login credentials");
            }

            return tokenResult;
        }
    }
}
