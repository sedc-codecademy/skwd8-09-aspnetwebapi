using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Class02.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        public static List<string> notes = new List<string>
        {
            "Don't forget to water plant",
            "Remember that you don't have plants",
            "Remember to buy new plant",
            "Make a break every 1h of coding",
            "Drink coffee"
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
            catch(ArgumentOutOfRangeException ex)
            {
                return NotFound($"Note with id: {id} is not found! Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Problem with your request: {ex.Message}");
            }
        }

        //Example of another custome route (end-point)
        [HttpGet("{userId}/notes/{noteId}")]
        public ActionResult<string> GetNotes(int userId, int noteId)
        {
            string note = notes[noteId - 1];
            return $"User: {userId} | This user needs to: {note}";
        }

        [HttpGet("info")]
        public ActionResult<string> Info()
        {
            var request = Request;
            return Ok($"This is a successful request! {request}");
        }

        [HttpPost]
        public IActionResult Post()
        {
            string note;
            using (StreamReader sr = new StreamReader(Request.Body))
            {
                note = sr.ReadToEnd();
            }
            if (!String.IsNullOrEmpty(note))
            {
                notes.Add(note);
            }
            else
            {
                return BadRequest($"Note not added succesfully!");
            }
            return Ok($"Note with id: {notes.Count - 1} successfully added!");
        }

    }
}
