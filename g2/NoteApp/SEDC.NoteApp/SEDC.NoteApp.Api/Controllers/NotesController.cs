using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NoteApp.Models;
using SEDC.NoteApp.Services;

namespace SEDC.NoteApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<NoteModel>> Get()
        {
            try
            {
                int userId = 1;
                return Ok(_noteService.GetUserNotes(userId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong. Please contact support! Message: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<NoteModel> Get(int id)
        {
            try
            {
                int userId = 1;
                return Ok(_noteService.GetNote(id, userId));
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong. Please contact support! Message: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] NoteModel model)
        {
            try
            {
                _noteService.AddNote(model);
                return Ok("Successfully added note!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong. Please contact support! Message: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int userId = 1;
                _noteService.DeleteNote(id, userId);
                return Ok("Note deleted successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong. Please contact support! Message: {ex.Message}");
            }
        }
    }
}
