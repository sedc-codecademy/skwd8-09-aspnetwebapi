using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace First_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //public List<User> users;
        //public ValuesController()
        //{
        //    users = new List<User>()
        //    {
        //        new User()
        //        {
        //            Id = 1,
        //            Name= "Goce Kabov",
        //            Age = 28
        //        },
        //        new User()
        //        {
        //            Id = 2,
        //            Name = "Darko Panchevski",
        //            Age = 24
        //        }
        //    };
        //}

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        
        [HttpGet("getAll")]
        public ActionResult<List<User>> GetAllUsers()
        {
            return Database.GetAllUsers();
        }

        // POST api/values
        [HttpPost("addNewUser")]
        public void Post([FromBody] User user)
        {
            var users = Database.GetAllUsers();
            user.Id = users.Count + 1;
            users.Add(user);
            Database.UpdateDatabase(users);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("deleteUser/{id}")]
        public ActionResult Delete(int id)
        {
            var user = Database.GetAllUsers().SingleOrDefault(u => u.Id == id);
            if (user == null) return BadRequest($"No such user with {id} id!");
            var users = Database.GetAllUsers();
            users.Remove(user);
            Database.UpdateDatabase(users);
            return Ok($"{user.Name} was successfully deleted from database");

        }

        //[Route("getAll/{id:int}")]
        //[HttpGet]
        //public ActionResult<string> GetAllUsers(int id)
        //{
        //    return $"Eve ti gi site useri so {id} ID";
        //}
    }
}
