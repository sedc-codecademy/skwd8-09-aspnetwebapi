using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Class03.EntityFramework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Class03.EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public static List<Book> books = new List<Book>
        {
            new Book(1, "Book 1"),
            new Book(2, "A javascript book"),
            new Book(3, "Book about CSharp"),
            new Book(4, "ASP .NET basics")
        };

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return books;
        }

        // GET api/values/5
        [HttpGet("{id:int:min(1)}")]
        public ActionResult<Book> Get(int id)
        {
            return books.SingleOrDefault(x => x.Id == id);
        }

        [HttpGet("{name:alpha}")]
        public ActionResult<List<Book>> GetByName(string name)
        {
            return books.Where(x => x.Title.ToLower().Contains(name) || x.Title.ToLower().StartsWith(name)).ToList();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

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
