using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NotesApp.Models;
using SEDC.NotesApp.Services.Interfaces;
using SEDC.NotesApp.Shared.Exceptions;

namespace SEDC.NotesApp.Controllers
{
    [Authorize] //all actions require the user to be authenticated/logged
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous] // the user can be unauthenticated
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel registerModel)
        {
            try
            {
                _userService.RegisterUser(registerModel);
                return Ok("User registered!");
            }
            catch (UserException e)
            {
                return BadRequest(e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured!");
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] LoginModel loginModel)
        {
            try
            {
                return Ok(_userService.LoginUser(loginModel));
            }
            catch (NotFoundException e)
            {
                return StatusCode(StatusCodes.Status401Unauthorized,"The user was not identified!");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occured!");
            }
        }
    }
}
