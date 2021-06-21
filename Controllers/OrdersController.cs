using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PwiAPI.DTOs;
using PwiAPI.Repositories;
using PwiAPI.Services;

namespace PwiAPI.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly OrdersRepository _ordersRepo;
        private readonly UsersService _usersService;

        public OrdersController(OrdersRepository ordersRepo, UsersService usersService)
        {
            _ordersRepo = ordersRepo;
            _usersService = usersService;
        }

        [Authorize]
        [HttpGet("details")]
        public IActionResult GetAllOrdersWithDetailsOfUser([FromHeader] HeaderDTO header)
        {
            var user = _usersService.GetUserFromHeader(header);
            var orders = _ordersRepo.GetAllOrderOfUser(user);
            return Ok(orders);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllOrdersOfUser([FromHeader] HeaderDTO header)
        {
            var user = _usersService.GetUserFromHeader(header);
            var orders = _ordersRepo.GetAllOrderOfUser(user);
            return Ok(orders);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddOrder([FromHeader] HeaderDTO header, [FromBody] OrderAddDTO newOrder)
        {
            var user = _usersService.GetUserFromHeader(header);
            _ordersRepo.AddOrder(user, newOrder);
            return Ok("Order added succesfully");
        }
    }
}
