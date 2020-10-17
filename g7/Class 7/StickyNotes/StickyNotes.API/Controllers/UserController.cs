using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StickyNotes.API.Models;
using StickyNotes.DataAccess.Domain;
using StickyNotes.PresentationLayer.Responses;
using StickyNotes.Services.Services.Interfaces;
using System.Collections.Generic;

namespace StickyNotes.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] CreateUserRequest request)
        {
            var user = _userService.Register(request);

            if (user != null)
            {
                return Ok(user);
            }

            return Conflict();
        }

        [AllowAnonymous]
        [HttpGet("authenticate")]
        public IActionResult Authenticate([FromQuery] string username, string password)
        {
            var user = _userService.Authenticate(username, password);

            if (user != null)
            {
                return Ok(user);
            }

            return BadRequest();
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<GetUserResponse>> GetUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet]
        public ActionResult<GetUserResponse> GetUserById([FromQuery] int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        [HttpPost("create")]
        public ActionResult<User> CreateUser([FromBody] GetUserResponse userRequest)
        {
            _userService.CreateUser(userRequest);

            return Ok("The user was added");
        }
    }
}
