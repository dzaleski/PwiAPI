using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PwiAPI.DTOs;
using PwiAPI.Helpers;
using PwiAPI.Services;

namespace PwiAPI.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UsersService _usersService;
        public AuthController(UsersService usersService, IConfiguration config)
        {
            _usersService = usersService;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Login")]
        public IActionResult Login([FromBody] UserLoginDTO userLoginDto)
        {
            var validatedUser = _usersService.Login(userLoginDto.Email, userLoginDto.Password);

            if (validatedUser == null)
            {
                return Unauthorized();
            }

            var tokenString = JwtTokenHelper.GenerateJSONWebToken(validatedUser, _config);

            return Ok(new { token = tokenString });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Register")]
        public IActionResult Register([FromBody] UserRegisterDTO userRegisterDto)
        {
            bool registered = _usersService.Register(userRegisterDto.Email, userRegisterDto.Password);

            if (!registered)
            {
                return Unauthorized("Wrong email or password!");
            }

            return Ok("Succesfully registered!");
        }
    }
}
