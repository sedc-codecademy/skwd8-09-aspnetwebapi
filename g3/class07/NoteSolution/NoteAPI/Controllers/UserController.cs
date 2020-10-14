using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using Services.Interfaces;

namespace NoteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterUserDto user)
        {
            try
            {
                _userService.Register(user);

                return Ok("User created");
            }
            catch (Exception ex)
            {
                return BadRequest(new Exception(ex.Message));
            }
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(string username,string password)
        {
            try
            {
                var result = _userService.Authenticate(username, password);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new Exception(ex.Message));
            }
        }

    }
}
