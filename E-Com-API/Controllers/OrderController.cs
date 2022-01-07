using DAL.Interfaces;
using E_Com_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceInterface;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Com_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("allOrders")]
        public IActionResult GetOrders()
        {
            int userId = Convert.ToInt32(User.Identity.Name.ToString()); 

            return Ok(_orderService.GetAllOrders(userId));
        }

        [HttpPost]
        [Route("createOrders")]
        public IActionResult CreateOrders([FromBody] OrderViewModel order)
        {
            int userId = Convert.ToInt32(User.Identity.Name.ToString());

            if(order.CartItems == null)
            {
                return BadRequest(new { message = "cart items cannot be empty"});
            }

            order.UserId = userId;
            _orderService.CreateOrder(order);

            return Ok(new { message = "Successfully order placed" });
        }
    }
}
