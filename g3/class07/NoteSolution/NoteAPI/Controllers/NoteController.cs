using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entity;
using Models.Dto;
using Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace NoteAPI.Controllers
{
    // All controller methods should be as clean as possible, no unnecessary logic should be added
    // FUN-FACT: each action is one-liner.

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService; // INoteService will be resolved to an object of NoteService
        public NoteController(INoteService noteService) // The dependency injection container will pass an object of NoteService, this is configured in Startup.cs
        {
            _noteService = noteService;
        }


        [HttpGet("getall")]
        public IEnumerable<NoteGetAllDto> GetAll()
        {
            return _noteService.GetAll();
        }

        [HttpGet("getall/{userId}")]
        public IEnumerable<NoteGetAllDto> GetAllById()
        {
            var userId = GetAuthorizedUserId();
            return _noteService.GetAll(userId);
        }

        [HttpGet("getbyid")]
        public Note GetById(Guid noteId)
        {
            var userId = GetAuthorizedUserId();
            return _noteService.GetById(noteId, userId);
        }

        [HttpPost("add")]
        public Note Add(NoteAddDto model)
        {
            return _noteService.Add(model);
        }

        [HttpPut("edit")]
        public Note Edit(NoteEditDto model)
        {
            return _noteService.Edit(model);
        }

        [HttpDelete("delete")]
        public bool Delete(Guid noteId)
        {
            var userId = GetAuthorizedUserId();
            return _noteService.Delete(noteId,userId);
        }

        private Guid GetAuthorizedUserId()
        {
            if (!Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId))
            {
                string name = User.FindFirst(ClaimTypes.Name)?.Value;
                throw new Exception("Name identifier claim does not exist!");
            }
            return userId;
        }
    }
}
