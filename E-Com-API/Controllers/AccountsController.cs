using DAL.Interfaces;
using E_Com_API.Service;
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
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public AccountsController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpGet]
        [Route("AllUsers")]
        public IActionResult GetAllUser()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult RegisterUserUser([FromBody] RegisterUser registerUser)
        {


            bool registerd = _userService.CreateUser(registerUser);
            if (registerd)
            {
                return Ok(new { message = "User Register Succesfull" });
            }

            return BadRequest(new { message = "User Email already registerd" });
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginUserModel model)
        {
            var user = _authService.Authenticate(model.UserName, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}
