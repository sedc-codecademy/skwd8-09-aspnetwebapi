using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StickyNotes.API.Models;
using StickyNotes.DataAccess.Entities;
using StickyNotes.DataAccess.Repositories;
using System;
using System.Collections.Generic;

namespace StickyNotes.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<User>> GetUsers([FromQuery] bool showNotes)
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById([FromQuery] int id)
        {
            var user = _userRepository.GetById(id);
            return Ok(user);
        }

        [HttpPost("create")]
        public ActionResult<User> CreateUser([FromBody] CreateUserRequest userRequest)
        {
            User user = new User
            {
                CreatedOn = DateTime.UtcNow,
                DeletedOn = null,
                FirstName = userRequest.Firstname,
                LastName = userRequest.LastName,
                Username = userRequest.Username,
                Password = userRequest.Password,
                Notes = new List<Note>()
            };

            _userRepository.Add(user);
            _userRepository.Save();

            return StatusCode(StatusCodes.Status409Conflict, "The user already exists");
        }
    }
}
