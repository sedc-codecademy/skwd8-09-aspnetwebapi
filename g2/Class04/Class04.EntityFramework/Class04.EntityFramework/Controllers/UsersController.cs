using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Class04.EntityFramework.DataModels.CreatedFromDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Class04.EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly NotesExampleContext _context;
        public UsersController(NotesExampleContext context)
        {
            _context = context;
        }

        // GET: api/<UsersController>

        // ******** JUST FOR DEMO (DO NOT EVER OPEN DB CONTEXT IN THE API CONTROLLERS) ***********
        [HttpGet]
        public ActionResult<List<Users>> Get()
        {
            var users = _context.Users
                        .Include(x => x.Notes)
                        .ToList();
            return users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<string> Post([FromBody] Users user)
        {
            if(user != null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok("The user is created successfully!");
            }
            return BadRequest("The user creation failed!");
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
