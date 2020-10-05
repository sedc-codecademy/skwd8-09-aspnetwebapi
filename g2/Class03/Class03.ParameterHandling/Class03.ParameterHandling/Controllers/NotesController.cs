using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Class03.ParameterHandling.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        public static List<Note> notes = new List<Note>()
        {
            new Note(){ Text = "Don't forget to water the plant", Color = "blue", Tags = new List<Tag>()
                {
                    new Tag(){ Name = "Home", Color = "cyan"},
                    new Tag(){ Name = "Priority Low", Color = "green"}
                }
            },
            new Note(){ Text = "Drink more Tea", Color = "blue", Tags = new List<Tag>()
            {
                    new Tag(){ Name = "Misc", Color = "orange"},
                    new Tag(){ Name = "Priority Low", Color = "green"}
                }
            },
            new Note(){ Text = "Make a break every 1h of coding", Color = "blue", Tags = new List<Tag>()
            {
                    new Tag(){ Name = "work", Color = "blue"},
                    new Tag(){ Name = "Priority Medium", Color = "yellow"}
                }
            }
        };


        [HttpGet]
        public ActionResult<IEnumerable<Note>> Get()
        {
            return notes;
        }



        //[HttpGet("{id}")]
        //public ActionResult<Note> Get(int id)
        //{
        //    try
        //    {
        //        return notes[id - 1];
        //    }
        //    catch (ArgumentOutOfRangeException)
        //    {
        //        return NotFound($"Note with id: {id} not found!");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"BROKEN REQUEST: {ex.Message}");
        //    }
        //}

        [HttpGet("{queryId}")]
        public ActionResult<Note> GetIdQuery(int id)
        {
            try
            {
                return notes[id - 1];
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound($"Note with id: {id} not found!");
            }
            catch (Exception ex)
            {
                return BadRequest($"BROKEN REQUEST: {ex.Message}");
            }
        }

        [HttpPost("query1")]
        public ActionResult Post1(string text, string color)
        {
            Note note = new Note
            {
                Text = text,
                Color = color
            };
            notes.Add(note);
            return Ok("A note has been created!");
        }
        
        [HttpPost("query2")]
        public IActionResult Post2([FromQuery] Note note)
        {
                if(note != null)
            {
                notes.Add(note);
                return Ok("Note created successfully!");
            };
            return BadRequest("Note creation failed!");
        }

        [HttpPost("query3")]
        public IActionResult Post3([FromQuery] Note note, [FromQuery] Tag tag)
        {
            note.Tags = new List<Tag> { tag };
            if (note != null)
            {
                notes.Add(note);
                return Ok("Note created successfully!");
            };
            return BadRequest("Note creation failed!");
        }

        [HttpPost("body")]
        public IActionResult Post4([FromBody] Note note)
        {
            if (note != null)
            {
                notes.Add(note);
                return Ok("Note created successfully!");
            };
            return BadRequest("Note creation failed!");
        }


        [HttpGet("header1")]
        public IActionResult GetHeader1([FromHeader] string host)
        {
            return Ok($"You are accessing {host}!");
        }

        [HttpGet("header2")]
        public IActionResult GetHeader2([FromHeader] string host, [FromHeader] string lang)
        {
            if(lang == "mk-MK")
            {
                return Ok($"Пристапувате до {host}");
            }
            return Ok($"You are accessing {host}");
        }
    }
}
