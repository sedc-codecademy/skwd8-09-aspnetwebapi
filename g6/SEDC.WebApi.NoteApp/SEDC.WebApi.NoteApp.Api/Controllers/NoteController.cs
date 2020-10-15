using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.NoteApp.Models;
using SEDC.WebApi.NoteApp.Services.Exceptions;
using SEDC.WebApi.NoteApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SEDC.WebApi.NoteApp.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            this._noteService = noteService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<NoteDto>> Get()
        {
            try
            {
                var userId = GetAuthorizedUserId();
                return Ok(_noteService.GetUserNotes(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<NoteDto> Get(int id)
        {
            try
            {
                var userId = GetAuthorizedUserId();
                return Ok(_noteService.GetNote(id, userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var userId = GetAuthorizedUserId();
                _noteService.DeleteNote(id, userId);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]NoteDto request)
        {
            try
            {
                request.UserId = GetAuthorizedUserId();
                _noteService.AddNote(request);
                // TODO: return create response
                return Ok("Success");
            }
            catch(NoteException ex)
            {
                Debug.WriteLine($"NOTE: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"NOTE: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        private int GetAuthorizedUserId()
        {
            if (!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier).Value
                , out var userId))
            {
                string name = User.FindFirst(ClaimTypes.Name).Value;
                throw new UserException(userId, name,
                    "Name identifier claims does not exists");
            }
            return userId;
        }
    }
}
