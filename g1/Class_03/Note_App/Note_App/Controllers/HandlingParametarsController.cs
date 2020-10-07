using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Note_App.Models;

namespace Note_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandlingParametarsController : ControllerBase
    {
        // path variables (route parametars)
        // http://localhost:[port]/api/handlingparametars/{id}
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
        [HttpGet("getByQueryId")]
        public ActionResult<Note> GetByIdWithQueryParam(int id)
        {
            if (id < 1) return StatusCode(StatusCodes.Status400BadRequest,
              new { message = "Id cant be lower then one" });
            var note = StaticDb.AdvanceNotes.SingleOrDefault(n => n.Id == id);
            if (note == null)
                return StatusCode(StatusCodes.Status404NotFound);

            return Ok(note);
        }

        [HttpPost]
        public ActionResult CreateNote([FromBody] Note note)
        {
            try
            {
                StaticDb.AdvanceNotes.Add(note);
                return StatusCode(StatusCodes.Status201Created, "Note successfully created");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("createNoteFromQuery")]
        public ActionResult CreateNoteFromQuery([FromQuery] Note note)
        {
            try
            {
                StaticDb.AdvanceNotes.Add(note);
                return StatusCode(StatusCodes.Status201Created, "Note successfully created");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("createNoteFromQuery1")]
        public ActionResult CreateNoteFromQuery1(int id, string text, string color)
        {
            try
            {
                var note = new Note()
                {
                    Id = id,
                    Text = text,
                    Color = color
                };
                StaticDb.AdvanceNotes.Add(note);
                return StatusCode(StatusCodes.Status201Created, "Note successfully created");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] Note note)
        {
            try
            {
                
                StaticDb.AdvanceNotes.Add(note);
                return StatusCode(StatusCodes.Status201Created, "Note successfully created");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("handleHostParam")]
        public ActionResult GetHostParam([FromHeader] string host, 
            [FromHeader(Name="Accept-Language")] string language)
        {
            if (language == "mk-MK")
            {
                return Ok($"Пристапувате до {host}");
            }
            return Ok($"You are accessing {host}");
        }
    }
}
