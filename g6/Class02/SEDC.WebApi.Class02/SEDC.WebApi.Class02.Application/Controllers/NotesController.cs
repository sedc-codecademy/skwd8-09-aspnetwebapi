using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.WebApi.Class02.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        public static List<string> notes = new List<string>
        {
            "Don't forget to water plant", "Remember that you don't have plants",
            "Remember to buy new plant", "Make a break every 1h of coding",
            "Drink Tea"
        };

        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            return notes;
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                return notes[id - 1];
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound($"Note with id: {id} was not found!");
            }
            catch(Exception ex)
            {
                return BadRequest($"Problem with your request: {ex.Message}");
            }
        }

        [HttpGet("info")]
        public ActionResult<string> Info()
        {
            var request = Request;
            return Ok("This is a notes application. It has notes in it.");
        }

        [HttpPost]
        public ActionResult Post()
        {
            string bodyContent = string.Empty;

            using (StreamReader sr = new StreamReader(Request.Body))
            {
                bodyContent = sr.ReadToEnd();
            }

            notes.Add(bodyContent);
            // return Created($"http://localhost:49568/api/notes/{notes.Count - 1}", bodyContent);
            return Ok($"Note with id {notes.Count - 1} successfuly created");
        }
    }
}
