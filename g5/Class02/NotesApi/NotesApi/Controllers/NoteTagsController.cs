using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NotesApi.Models;

namespace NotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteTagsController : ControllerBase
    {
        [HttpGet]
        //[Route("notes")]
        public ActionResult<List<Note>> GetAll()
        {
            return StaticDb.NoteTags;
        }

        //[HttpPost]
        //public async Task<IActionResult> AddNewNote()
        //{
        //    try
        //    {
        //        using (StreamReader streamReader = new StreamReader(Request.Body))
        //        {
        //            string content = await streamReader.ReadToEndAsync();
        //            //Note newNote = JsonSerializer.Deserialize<Note>(content);
        //            Note newNote = JsonConvert.DeserializeObject<Note>(content);
        //            StaticDb.NoteTags.Add(newNote);
        //            return StatusCode(StatusCodes.Status201Created, "Created");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status409Conflict, "Error Happened");
        //    }
        //}

        [HttpPost]
        public IActionResult AddNewNote(Note note)
        {
            try
            {
                StaticDb.NoteTags.Add(note);
                return StatusCode(StatusCodes.Status201Created, "Created");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, "Error Happened");
            }
        }
    }
}
