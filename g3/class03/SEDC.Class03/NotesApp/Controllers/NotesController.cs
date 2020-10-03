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

namespace NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        // URL: http://localhost:47893/api/notes/getall
        [HttpGet("getall")]
        public ActionResult<IEnumerable<NoteDtoGetAll>> GetAll()
        {
            IEnumerable<NoteDtoGetAll> result = StaticDB.Notes.Select(n => new NoteDtoGetAll
            {
                Id = n.Id,
                Title = n.Title,
                DueDate = n.DueDate
            });

            if (!result.Any())
            {
                return this.StatusCode(int.Parse(HttpStatusCode.NoContent.ToString()));
            }
            return Ok(result);
        }    

        [HttpGet("get/{id}")]
        public ActionResult<Note> Get(Guid id)
        {
            Note note = StaticDB.Notes.FirstOrDefault(n => n.Id == id);

            if (note == null)
            {
                return this.NotFound($"Note with {id} was not found!");
            }
            return this.Ok(note);
        }

        [HttpPost("add")]
        public ActionResult<Note> Add([FromBody]NoteDtoAdd model)
        {
            Note newNote = new Note
            {
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate
            };

            try
            {
                StaticDB.Notes.Add(newNote);
            }
            catch (Exception ex)
            {
                return this.StatusCode(int.Parse(HttpStatusCode.InternalServerError.ToString()), ex.Message);
            }
            
            return Ok(newNote);
        }

        [HttpPut("edit")]
        public ActionResult<Note> Edit([FromBody]NoteDtoEdit model)
        {
            Note oldNote = StaticDB.Notes.FirstOrDefault(n => n.Id == model.Id);

            if (oldNote == null)
            {
                return this.NotFound($"Note with {model.Id} was not found!");
            }

            oldNote.Title = !string.IsNullOrWhiteSpace(model.Title) ? model.Title : oldNote.Title;
            oldNote.Description = !string.IsNullOrWhiteSpace(model.Description) ? model.Description : oldNote.Description;
            oldNote.DueDate = !(model.DueDate == null) ? model.DueDate : oldNote.DueDate;

            return Ok(oldNote);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<bool> Delete(Guid id)
        {
            Note noteDel =  StaticDB.Notes.FirstOrDefault(n => n.Id == id);

            if (noteDel == null)
            {
                return this.NotFound(false);
            }
            try
            {
                StaticDB.Notes.Remove(noteDel);
            }
            catch (Exception ex)
            {
                return this.StatusCode(int.Parse(HttpStatusCode.InternalServerError.ToString()), new { ex, isSuccess = false });
            }

            return Ok(true);
        }
    }
}
