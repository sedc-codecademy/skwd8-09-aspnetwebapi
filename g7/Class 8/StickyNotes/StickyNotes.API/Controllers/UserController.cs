using Microsoft.AspNetCore.Mvc;
using StickyNotes.DataAccess.Domain;
using StickyNotes.PresentationLayer.Responses;
using StickyNotes.Services.Services.Interfaces;
using System.Collections.Generic;

namespace StickyNotes.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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

        [HttpGet("maxNotes")]
        public ActionResult<List<User>> GetUsersWithMostNotes()
        {
            var usersResponse = _userService.GetUsersWithMostNotes();
            return Ok(usersResponse);
        }

        [HttpGet("sameLength/{length}")]
        public ActionResult<List<GetUserResponse>> GetUsersWithSameLength([FromRoute] int length)
        {
            var usersResponse = _userService.GetUserswithSameUsernameLength(length);
            return Ok(usersResponse);
        }

        [HttpPost("create")]
        public ActionResult<User> CreateUser([FromBody] GetUserResponse userRequest)
        {
            _userService.CreateUser(userRequest);

            return Ok("The user was added");
        }

        [HttpPut]
        public ActionResult<User> UpdateUser([FromBody] GetUserResponse userRequest)
        {
            _userService.UpdateUser(userRequest);
            return Ok();
        }
    }
}
