using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        //[HttpGet]
        //public List<string> GetAll()
        //{
        //    //Thread.Sleep(10000);
        //    return StaticDb.Notes;
        //}

        //[HttpGet]
        //public ActionResult<List<string>> GetAll()
        //{
        //    return Ok(StaticDb.Notes);
        //}

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    return StatusCode(StatusCodes.Status200OK, StaticDb.Notes);
        //}

        [HttpGet]
        public ActionResult<List<string>> GetAll()
        {
            return StatusCode(StatusCodes.Status200OK, StaticDb.Notes);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<string> GetById(int id)
        {
            //if (id >= StaticDb.Notes.Count)
            //{
            //    return NotFound();
            //}

            //if (id < 0)
            //{
            //    return NotFound();
            //}

            try
            {
                if (id >= StaticDb.Notes.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        $"We have only {StaticDb.Notes.Count} notes, please specify number between 0 - {StaticDb.Notes.Count - 1}");
                }

                //if (id < 0)
                //{
                //    return StatusCode(StatusCodes.Status404NotFound, "Please specify positive number");
                //}

                return StatusCode(StatusCodes.Status200OK, StaticDb.Notes[id]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, "Error happened, please contact the admins");
            }
        }

        [HttpGet]
        [Route("user/{user}/note/{noteId}")]
        public ActionResult<string> GetNote(string user, int noteId)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, $"{user}: {StaticDb.Notes[noteId]}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, "Error happened, please contact the admins");
            }
        }

        //[HttpPost]
        //public IActionResult AddNewNote()
        //{
        //    try
        //    {
        //        using (var streamReader = new StreamReader(Request.Body))
        //        {
        //            var content = streamReader.ReadToEndAsync().Result;
        //            StaticDb.Notes.Add(content);
        //            return StatusCode(StatusCodes.Status201Created, "New note added!");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status409Conflict, "Error Happened.");
        //    }
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddNewNote()
        //{
        //    try
        //    {
        //        using (var streamReader = new StreamReader(Request.Body))
        //        {
        //            var content = await streamReader.ReadToEndAsync();
        //            StaticDb.Notes.Add(content);
        //            return StatusCode(StatusCodes.Status201Created, "New note added!");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status409Conflict, "Error Happened.");
        //    }
        //}

        [HttpPost]
        public IActionResult AddNewNote(string note)
        {
            try
            {
                StaticDb.Notes.Add(note);
                return StatusCode(StatusCodes.Status201Created, "New note added!");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status409Conflict, "Error Happened.");
            }
        }
    }
}
