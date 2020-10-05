using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> GetAllTeams()
        {
            return Ok("we are here");
        }
    }
}