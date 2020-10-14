using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NoteApp.Models;
using SEDC.NoteApp.Services;

namespace SEDC.NoteApp.Api.Controllers
{
    [Authorize]
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
                //int userId = 1;
                int userId = GetAuthorizedUserId();
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
                //int userId = 1;
                int userId = GetAuthorizedUserId();
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
                model.Id = GetAuthorizedUserId();
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
                //int userId = 1;
                int userId = GetAuthorizedUserId();
                _noteService.DeleteNote(id, userId);
                return Ok("Note deleted successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong. Please contact support! Message: {ex.Message}");
            }
        }


        private int GetAuthorizedUserId()
        {
            if(!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId))
            {
                string name = User.FindFirst(ClaimTypes.Name)?.Value;
                throw new Exception("Name identifier claim does not exist!");
            }
            return userId;
        }
    }
}
