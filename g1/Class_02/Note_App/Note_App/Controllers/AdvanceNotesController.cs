using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Note_App.Models;

namespace Note_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvanceNotesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Note>> GetNotes()
        {
            return Ok(StaticDb.AdvanceNotes);
        }
        [HttpGet("{id}")]
        public ActionResult<Note> GetById(int id)
        {
            if (id < 1) return StatusCode(StatusCodes.Status400BadRequest,
               new { message = "Id cant be lower then one" });
            var note = StaticDb.AdvanceNotes.SingleOrDefault(n => n.Id == id);
            if (note == null)
                return StatusCode(StatusCodes.Status404NotFound);

            return Ok(note);

        }
        [HttpPost]
        public ActionResult CreateNote()
        {
            try
            {
                using(StreamReader sr = new StreamReader(Request.Body))
                {
                    var jsonBody = sr.ReadToEnd();
                    var note = JsonConvert.DeserializeObject<Note>(jsonBody);
                    StaticDb.AdvanceNotes.Add(note);
                    return StatusCode(StatusCodes.Status201Created, "Note successfully created");
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}