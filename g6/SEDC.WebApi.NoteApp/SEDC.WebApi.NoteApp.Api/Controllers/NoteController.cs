using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.NoteApp.Models;
using SEDC.WebApi.NoteApp.Services.Exceptions;
using SEDC.WebApi.NoteApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public ActionResult<IEnumerable<NoteDto>> Get([FromQuery]int id)
        {
            try
            {
                return Ok(_noteService.GetUserNotes(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<NoteDto> Get(int id, [FromQuery]int userId)
        {
            try
            {
                return Ok(_noteService.GetNote(id, userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id, [FromQuery]int userId)
        {
            try
            {
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


    }
}
