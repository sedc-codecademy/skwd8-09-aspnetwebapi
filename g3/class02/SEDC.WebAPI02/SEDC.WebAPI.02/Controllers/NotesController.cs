using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SEDC.WebAPI02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        // Static list of notes as mock DB
        // Index == id
        public static List<string> notes = new List<string>()
        {
            "Don't forget to water plant", "Remember that you don't have plants",
            "Remember to buy new plant", "Make a break every 1h of coding",
            "Drink Tea"
        };

        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            return notes;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return notes[id - 1];
        }
        [HttpGet("info")]
        public string Info()
        {
            // Example of a request. Put breakpoint to show the Request object
            var request = Request;
            return "This is a notes application. It has notes in it.";
        }
        [HttpPost]
        public string Post()
        {
            string body;
            // Extracting data from Body manually
            using (StreamReader sr = new StreamReader(Request.Body))
            {
                body = sr.ReadToEnd();
            }
            notes.Add(body);
            return $"Note with id {notes.Count - 1} successfuly created";
        }
    }
}
