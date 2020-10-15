using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.WebApi.NoteApp.Services.Interfaces;

namespace SEDC.WebApi.NoteApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalController : ControllerBase
    {
        private readonly INoteService _noteService;

        public ExternalController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet("performance/getnote")]
        public ActionResult<long> GetNotesPerformance()
        {
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < 1000; i++)
            {
                _noteService.GetNote(1, 1);
            }
            stopwatch.Stop();
            var elapsed = stopwatch.ElapsedMilliseconds;
            return elapsed;
        }
    }
}
