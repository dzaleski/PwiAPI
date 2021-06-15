using Microsoft.AspNetCore.Mvc;
using PwiAPI.DTOs;
using PwiAPI.Services;

namespace PwiAPI.Controllers
{
    public class UsersController : BaseController
    {
        private readonly UsersService _usersService;

        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public IActionResult GetCurrentUser(string token)
        {
            var userFromSerivce = _usersService.GetCurrentUser(token);
            
            return Ok(new CurrentUserDTO() { 
                Id = userFromSerivce.Id,
                Email = userFromSerivce.Email,
                AccountBalance = userFromSerivce.AccountBalance
            });
        }
    }
}
