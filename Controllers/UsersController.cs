using Microsoft.AspNetCore.Mvc;
using PwiAPI.DTOs;
using PwiAPI.Services;
using System.Net;

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
        public IActionResult GetCurrentUser([FromHeader] HeaderDTO header)
        {
            var userFromService = _usersService.GetUserFromHeader(header);

            return Ok(new CurrentUserDTO()
            {
                Id = userFromService.Id,
                Email = userFromService.Email,
                AccountBalance = userFromService.AccountBalance
            });
        }
    }
}
