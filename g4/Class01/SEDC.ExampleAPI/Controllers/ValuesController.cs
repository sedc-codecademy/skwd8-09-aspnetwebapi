using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.ExampleAPI.Models;

namespace SEDC.ExampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5/1
        [HttpGet("{id}/{bookId}")]
        public ActionResult<Book> Get(int id, int bookId)
        //public ActionResult<string> Get(int id)
        {
            return new Book {Id = 1, Title = "Kasni Porasni"};
            // return "value";
        }

        //GET api/values/integer
        [HttpGet("integer")]
        public ActionResult<int> GetInteger()
        {
            return 5;
            //return true;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // POST api/values/postBook
        [HttpPost("postBook")]
        public ActionResult<Book> Post([FromBody] Book book)
        {
            return book;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
