using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using DummyData;
using Models.Dto;
using Remotion.Linq.Utilities;
using System.Net;
using Repository.Interfaces;

namespace NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private INotesRepository _notesRepository;

        public NotesController(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        // URL: http://localhost:47893/api/notes/getall
        [HttpGet("getall")]
        public ActionResult<IEnumerable<NoteDtoGetAll>> GetAll()
        {
            return Ok(_notesRepository.GetAll());
        }

        [HttpGet("get/{id}")]
        public ActionResult<Note> Get(Guid id)
        {
            var result = _notesRepository.Get(id);

            if (result == null) return NotFound();

            return result;
        }

        [HttpPost("add")]
        public ActionResult<Note> Add([FromBody]NoteDtoAdd model)
        {
            var result = _notesRepository.Add(model);

            if (result == null) BadRequest();

            return Ok(result);
        }

        [HttpPut("edit")]
        public ActionResult<Note> Edit([FromBody]NoteDtoEdit model)
        {
            var result = _notesRepository.Edit(model);

            if (result == null) BadRequest();

            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<bool> Delete(Guid id)
        {
            return _notesRepository.Delete(id);
        }
    }
}
