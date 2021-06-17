using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PwiAPI.DTOs;
using PwiAPI.Helpers;
using PwiAPI.Models;
using PwiAPI.Services;
using System.Data.Common;

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
        [Route("api/login")]
        public IActionResult Login([FromBody] UserLoginDTO userLoginDto)
        {
            var validatedUser = _usersService.Login(userLoginDto.Email, userLoginDto.Password);

            if (validatedUser == null)
            {
                return BadRequest(new ErrorResponse("Wrong email or password"));
            }

            var tokenString = JwtTokenHelper.GenerateJSONWebToken(validatedUser, _config);

            return Ok(new { token = tokenString });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/register")]
        public IActionResult Register([FromBody] UserRegisterDTO userRegisterDto)
        {
            try
            {
                _usersService.Register(userRegisterDto.Email, userRegisterDto.Password);
            }
            catch (DbUpdateException)
            {
                return BadRequest(new ErrorResponse("Email is already used!"));
            }

            return Ok("Succesfully registered!");
        }
    }
}
