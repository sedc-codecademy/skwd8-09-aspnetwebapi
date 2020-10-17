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

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IControllerUtilityService _controllerUtilityService;
        private readonly INoteService _noteService; // INoteService will be resolved to an object of NoteService
        public NoteController(INoteService noteService, IControllerUtilityService controllerUtilityService) // The dependency injection container will pass an object of NoteService, this is configured in Startup.cs
        {
            _controllerUtilityService = controllerUtilityService;
            _noteService = noteService;
        }

        [HttpGet("getall")]
        public IEnumerable<NoteGetAllDto> GetAll()
        {
            return _noteService.GetAll(_controllerUtilityService.GetAuthorizedUserId(User));
        }

        [HttpGet("getbyid")]
        public Note GetById(Guid noteId)
        {
            return _noteService.GetById(noteId);
        }

        [HttpPost("add")]
        public Note Add(NoteAddDto model)
        {
            Guid userId = _controllerUtilityService.GetAuthorizedUserId(User);
            return _noteService.Add(userId, model);
        }

        [HttpPut("edit")]
        public Note Edit(NoteEditDto model)
        {
            return _noteService.Edit(model);
        }

        [HttpDelete("delete")]
        public bool Delete(Guid noteId)
        {
            return _noteService.Delete(noteId);
        }
    }
}
