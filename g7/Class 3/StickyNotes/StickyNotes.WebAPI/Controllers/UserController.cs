using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StickyNotes.WebAPI.Database.Interfaces;
using StickyNotes.WebAPI.Entities;
using System.Collections.Generic;

namespace StickyNotes.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IDatabase _database;
        public UserController(IDatabase database)
        {
            _database = database;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers([FromQuery] bool showNotes)
        {
            var users = _database.SeedUsers(showNotes);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById([FromQuery] int id)
        {
            var user = _database.GetUserById(id);
            return Ok(user);
        }

        [HttpGet("byName")]
        public ActionResult<User> GetUserByFirstNameAndLastName([FromQuery] string firstName,string lastname)
        {
            var user = _database.GetUserByFirstNameAndLastName(firstName, lastname);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User user)
        {
            var userCreated = _database.CreateUser(user);
            if (userCreated)
            {
                return StatusCode(StatusCodes.Status201Created, "The user is created");
            }
            return StatusCode(StatusCodes.Status409Conflict, "The user already exists");
        }
    }
}
