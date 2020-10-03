using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Note_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        // GET: api/Notes
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //return Ok(StaticDb.GetSimpleNotes);
            return StatusCode(StatusCodes.Status200OK, StaticDb.GetSimpleNotes);
        }

        // GET: api/Notes/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0) return StatusCode(StatusCodes.Status400BadRequest,
                new { message = "Id cant be lower then zero" });
            if (id >= StaticDb.GetSimpleNotes.Count)
                return StatusCode(StatusCodes.Status404NotFound);
            return Ok(StaticDb.GetSimpleNotes[id]);

        }

        [HttpGet("{noteId}/user/{userId}")]
        public ActionResult<string> Get(int noteId, int userId)
        {
            return $"{StaticDb.GetSimpleNotes[noteId]} , userId: {userId}";
        }


        // POST: api/Notes
        [HttpPost]
        public ActionResult Post()
        {
            try
            {
                using (StreamReader sr = new StreamReader(Request.Body))
                {
                    string note = sr.ReadToEnd();
                    StaticDb.GetSimpleNotes.Add(note);
                    return StatusCode(StatusCodes.Status201Created, "Note was successfully created");

                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message
                    // message = "Something bad happened on server side, please try again later"
                });
            }

        }
    }
}
