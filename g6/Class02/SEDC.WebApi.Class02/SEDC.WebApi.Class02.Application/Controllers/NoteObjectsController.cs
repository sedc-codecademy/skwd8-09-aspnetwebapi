using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Newtonsoft.Json;
using SEDC.WebApi.Class02.Application.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.WebApi.Class02.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteObjectsController : ControllerBase
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
        public ActionResult<List<Note>> Get()
        {
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public ActionResult<Note> Get(int id)
        {
            // should have error handling
            return notes[id - 1];
        }

        // .../api/NotesObjcects/5(note id)/tags
        [HttpGet("{noteId}/tags")]
        public ActionResult<List<Tag>> Tags(int noteId)
        {
            // should have some error handling
            return notes[noteId - 1].Tags;
        }

        // .../api/NotesObjcects/5(note id)/tags/2(tag id)
        [HttpGet("{noteId}/tags/{tagId}")]
        public ActionResult<Tag> Tag(int noteId, int tagId)
        {
            // should have error hendling
            return notes[noteId - 1].Tags[tagId - 1];
        }

        [HttpPost]
        public IActionResult Post()
        {
            string bodyContent = string.Empty;
            using (var sr = new StreamReader(Request.Body))
            {
                bodyContent = sr.ReadToEnd();
            }
            Note note = JsonConvert.DeserializeObject<Note>(bodyContent);
            notes.Add(note);
            return Ok($"NOte with id: {notes.Count - 1} was added");
        }
    }
}
