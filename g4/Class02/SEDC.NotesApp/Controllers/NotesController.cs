using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SEDC.NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        [HttpGet] // GET api/notes
        public ActionResult<List<string>> Get()
        {
            //return Ok(StaticDb.SimpleNotes);
            return StatusCode(StatusCodes.Status200OK, StaticDb.SimpleNotes);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                if (id < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Id can't be lower than zero");
                }

                if (id >= StaticDb.SimpleNotes.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                return StaticDb.SimpleNotes[id];
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }

        [HttpGet("{noteId}/users/{userId}")]
        public ActionResult<string> Get(int noteId, int userId)
        {
            //return StaticDb.SimpleNotes[noteId] + "-" + userId;
            return $"{StaticDb.SimpleNotes[noteId]}, userId: {userId}";
        }

        [HttpGet("info")]
        public IActionResult Info()
        {
            var request = Request; //http request
           // return Ok("Your request was successful"); // return 200 (ok)
           return StatusCode(StatusCodes.Status200OK, "Your request was successful");
        }

        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                using (StreamReader reader = new StreamReader(Request.Body))
                {
                    string note = reader.ReadToEnd();
                    StaticDb.SimpleNotes.Add(note);
                    return StatusCode(StatusCodes.Status201Created, "Note added");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            try
            {
                using (StreamReader reader = new StreamReader(Request.Body))
                {
                    string idFromBody = reader.ReadToEnd();
                    int id = Int32.Parse(idFromBody);
                    StaticDb.SimpleNotes.RemoveAt(id);
                    return StatusCode(StatusCodes.Status204NoContent, "Note deleted");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }
    }
}
