using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SEDC.NotesApp.Models;

namespace SEDC.NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesTagsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Note>> Get()
        {
            return StatusCode(StatusCodes.Status200OK, StaticDb.Notes);
        }

        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                using (StreamReader reader = new StreamReader(Request.Body))
                {
                    string jsonBody = reader.ReadToEnd();
                    Note newNote = JsonConvert.DeserializeObject<Note>(jsonBody);
                    StaticDb.Notes.Add(newNote);
                    return StatusCode(StatusCodes.Status201Created);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Note> Get(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Something is wrong with your request");
                }
                if( id > StaticDb.Notes.Count)
                {
                    return NotFound("There is no note for that id");
                }

                return StaticDb.Notes[id - 1];
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Something went wrong!");
            }
        }
        //GET api/notestags/1/tags
        //get all tags for a note
        [HttpGet("{id}/tags")]
        public ActionResult<List<Tag>> Tags(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Something is wrong with your request");
                }
                if (id > StaticDb.Notes.Count)
                {
                    return NotFound("There is no note for that id");
                }

                return StaticDb.Notes[id - 1].Tags;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
            }
        }
        //GET api/notestags/1/tags/2
        //get specific tag from specific node
        [HttpGet("{noteId}/tags/{tagId}")]
        public ActionResult<Tag> GetTag(int noteId, int tagId)
        {
            try
            {
                if (noteId <= 0)
                {
                    return BadRequest("Something is wrong with your request");
                }
                if (noteId > StaticDb.Notes.Count)
                {
                    return NotFound("There is no note for that id");
                }

                return StaticDb.Notes[noteId - 1].Tags[tagId - 1];
            }
            catch (ArgumentOutOfRangeException e) // if we access tag id out of range
            {
                return BadRequest("There is something wrong with your request");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
            }
        }
    }
}
