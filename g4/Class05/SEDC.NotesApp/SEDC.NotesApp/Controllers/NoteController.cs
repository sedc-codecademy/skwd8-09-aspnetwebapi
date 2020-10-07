using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NotesApp.Domain.Models;
using SEDC.NotesApp.Services.Interfaces;

namespace SEDC.NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public ActionResult<List<Note>> Get()
        {
            return _noteService.GetAllNotes();
        }

        [HttpGet("{id}")]
        public ActionResult<Note> Get(int id)
        {
            return _noteService.GetNoteById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Note note)
        {
            _noteService.AddNote(note);
            return StatusCode(StatusCodes.Status201Created, "Note created!");
        }

        [HttpPut]
        public IActionResult Put([FromBody]Note note)
        {
            _noteService.UpdateNote(note);
            return StatusCode(StatusCodes.Status204NoContent, "Note updated!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _noteService.DeleteNote(id);
            return StatusCode(StatusCodes.Status204NoContent, "Note deleted!");
        }
    }
}
