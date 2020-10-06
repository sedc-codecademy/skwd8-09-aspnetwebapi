using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace PremierLeague.WebApi.Controllers
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
