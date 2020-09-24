using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.Template.App.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SEDC.WebApi.Template.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/<TestController>
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var user = new User
            {
                Id = 1,
                FirstName = "Trajan",
                LastName = "Stevkovski",
                DateOfBirth = DateTime.Now.AddYears(-30)
            };

            //return BadRequest();
            return Ok(new User[] { user, user, user, user });
        }

        [HttpGet("get-user/{id}")]
        public ActionResult<User> GetUserById(int id, [FromQuery] QueryParams query)
        {
            var user = new User
            {
                Id = id,
                FirstName = query.Name,
                LastName = query.LastName,
                DateOfBirth = DateTime.Now
            };
            return Ok(user);
        }

        [HttpGet("no-content")]
        public ActionResult NoContentResponse()
        {
            return NoContent();
        }

        [HttpGet("not-found")]
        public ActionResult NotFoundResponse()
        {
            return NotFound();
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestController>
        [HttpPost]
        public ActionResult Post([FromBody] PostBody body)
        {
            if (body.Value == "Trajan")
            {
                return BadRequest();
            }

            if (body.Value == "Tosho")
            {
                return NotFound();
            }

            return Ok(body.Value);
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
