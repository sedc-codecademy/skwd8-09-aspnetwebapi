using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain_Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Note_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private INoteService _noteService;
        private IUserService _userService;
        public NotesController(INoteService noteService, IUserService userService)
        {
            _noteService = noteService;
            _userService = userService;
        }
        // GET: api/<NotesController>
        [HttpGet]
        public ActionResult<List<Note>> Get()
        {
            try
            {
                return Ok(_noteService.GetAllNotes());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public ActionResult<Note> Get(int id)
        {
            try
            {
                return Ok(_noteService.GetNoteById(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<NotesController>
        [HttpPost]
        public ActionResult Post([FromQuery]int userId, [FromBody] Note note)
        {
            try
            {
                var user = _userService.GetUserById(userId);
                if (user == null) throw new Exception("Not valid user ID");
                note.UserId = userId;
                _noteService.AddNote(note);
                return Ok("Note successfully created");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<NotesController>/5
        [HttpPut]
        public ActionResult Put([FromBody] Note note)
        {
            try
            {
                var dbNote = _noteService.GetNoteById(note.Id);
                if (dbNote == null) 
                   throw new Exception("There is no such note to be updated");
                _noteService.UpdateNote(note);
                return Ok("Note updated successfully");
            }
            catch (Exception ex)
            {
                //return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _noteService.DeleteNote(id);
                return Ok("note successfully deleted");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
