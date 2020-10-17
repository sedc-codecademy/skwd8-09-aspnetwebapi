using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NotesApp.Models;
using SEDC.NotesApp.Services.Interfaces;
using SEDC.NotesApp.Shared.Exceptions;

namespace SEDC.NotesApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }
        
        [HttpGet]
        public ActionResult<List<NoteModel>> Get()
        {
            try
            {
                string userId = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
                string userFullname = User.Claims.First(x => x.Type == "userFullName").Value;
                int parsedUserId = Int32.Parse(userId);
                //return Ok(_noteService.GetAllNotes());
                return Ok(_noteService.GetNotesByUserId(parsedUserId));
            }
            catch
            {
                //log
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
            }
        }

        [HttpGet("httpContext")]
        public ActionResult<List<NoteModel>> GetNoteByUserIdFromContext()
        {
            try
            {
                //other way of getting info from the token
                var accessToken = HttpContext.GetTokenAsync("access_token").Result;
                JwtSecurityToken token = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
                //ClaimTypes is used with User (ClaimsPrincipal)
                string userId2 = token.Claims.First(x => x.Type == "nameid").Value;

                string userId = User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
                string userFullname = User.Claims.First(x => x.Type == "userFullName").Value;
                int parsedUserId = Int32.Parse(userId);
                //return Ok(_noteService.GetAllNotes());
                return Ok(_noteService.GetNotesByUserId(parsedUserId));
            }
            catch
            {
                //log
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<NoteModel> GetById(int id)
        {
            try
            {
                return Ok(_noteService.GetNoteById(id));
            }
            catch (NotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch(Exception e)
            {
                //log
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] NoteModel noteModel)
        {
            try
            {
                _noteService.AddNote(noteModel);
                return StatusCode(StatusCodes.Status201Created, "Note Created!");
            }
            catch (NoteException e)
            {
                //log
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch
            {
                //log
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] NoteModel noteModel)
        {
            try
            {
                _noteService.UpdateNote(noteModel);
                return StatusCode(StatusCodes.Status204NoContent, "Note updated!");
            }
            catch (NotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (NoteException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
            catch (Exception e)
            {
                //log
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
               _noteService.DeleteNote(id);
               return StatusCode(StatusCodes.Status204NoContent, "Note deleted!");
            }
            catch (NotFoundException e)
            {
                return StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (Exception e)
            {
                //log
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong!");
            }
        }

    }
}
