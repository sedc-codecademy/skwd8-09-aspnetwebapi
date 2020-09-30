using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NotesApp.Models;

namespace SEDC.NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        [HttpGet] //GET api/notes
        public ActionResult<List<Note>> Get()
        {
            try
            {
                return StaticDb.Notes;
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured");
            }
        }

        [HttpGet("{index}")] //GET api/notes/1
        public ActionResult<Note> Get(int index)
        {
            try
            {
                if (index<0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request!");
                }

                if (index >= StaticDb.Notes.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Note not found!");
                }

                return StatusCode(StatusCodes.Status200OK, StaticDb.Notes[index]);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured");
            }

        }

        [HttpGet("queryString")] //GET api/notes/queryString?index=1
        public ActionResult<Note> GetByQueryString(int index)
        {
            try
            {
                if (index < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request!");
                }

                if (index >= StaticDb.Notes.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Note not found!");
                }

                return StatusCode(StatusCodes.Status200OK, StaticDb.Notes[index]);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured");
            }
        }

        [HttpGet("{text}/{color}")] //GET api/notes/gym/blue
        public ActionResult<Note> GetByMultipleParams(string text, string color)
        {
            try
            {
                Note note = StaticDb.Notes
                    .FirstOrDefault(x => x.Text.Contains(text) && x.Color.Contains(color));
                if (note == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Note not found!");
                }

                return Ok(note);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured");
            }
        }

        [HttpGet("multipleQuery")] //GET api/notes/multipleQuery?text=gym&color=red
        public ActionResult<Note> GetByMultipleQueryParams(string text, string color)
        {
            try
            {
                if (string.IsNullOrEmpty(text) && string.IsNullOrEmpty(color))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Parameters are missing");
                }

                if (string.IsNullOrEmpty(text))
                {
                    Note note = StaticDb.Notes.FirstOrDefault(x => x.Color.Equals(color));
                    if (note == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, "note not found");
                    }

                    return Ok(note);
                }

                if (string.IsNullOrEmpty(color))
                {
                    Note note = StaticDb.Notes.FirstOrDefault(x => x.Text.Contains(text));
                    if (note == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, "note not found");
                    }
                    return Ok(note);
                }

                Note noteDb = StaticDb.Notes
                    .FirstOrDefault(x => x.Text.Contains(text) && x.Color.Contains(color));
                if (noteDb == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Note not found!");
                }
                return Ok(noteDb);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured");
            }
        }

        [HttpGet("postNote")] //GET api/notes/postNote?text=gym&color=red&name=testTag
        public IActionResult PostNoteWithQuery([FromQuery] Note note, [FromQuery] Tag tag)
        {
            return Ok();
        }

        [HttpGet("acceptHeader")] //GET api/notes/acceptHeader
        public IActionResult GetAcceptHeader([FromHeader(Name="Accept")] string acceptHeader)
        {
            var request = Request;
            return Ok(acceptHeader);
        }

        [HttpPost("postNoteWithoutTag")] //POST api/notes/postNoteWithoutTag
        public IActionResult PostNoteWithoutTag([FromBody] Note note)
        {
            try
            {
                StaticDb.Notes.Add(note);
                return StatusCode(StatusCodes.Status201Created, "Note added!");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured");
            }
        }

        [HttpPost("postNoteWithTag")] //POST api/notes/postNoteWithTag
        public IActionResult PostNoteWithTag([FromBody] Note note)
        {
            try
            {
                StaticDb.Notes.Add(note);
                return StatusCode(StatusCodes.Status201Created, "Note added!");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured");
            }
        }

        [HttpPut("put/{noteIndex}")] //PUT api/notes/put/1
        public IActionResult AddTag(int noteIndex, [FromBody] Tag tag)
        {
            try
            {

                if (noteIndex < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request!");
                }

                if (noteIndex >= StaticDb.Notes.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Note not found!");
                }

                Note note = StaticDb.Notes[noteIndex];
                if (note.Tags == null)
                {
                    note.Tags=new List<Tag>();
                }
                note.Tags.Add(tag);

                return StatusCode(StatusCodes.Status204NoContent, "Note updated with tag!");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured");
            }
        }
    }
}
