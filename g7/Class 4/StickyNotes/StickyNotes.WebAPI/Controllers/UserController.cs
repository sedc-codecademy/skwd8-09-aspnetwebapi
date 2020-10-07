using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StickyNotes.DataAccess.Entities;
using StickyNotes.DataAccess.Repositories;
using System.Collections.Generic;

namespace StickyNotes.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;

        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
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

        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User user)
        {
            _userRepository.Add(user);
            _userRepository.Save();

            return StatusCode(StatusCodes.Status409Conflict, "The user already exists");
        }
    }
}
