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
    public class PlayerController : ControllerBase
    {
        public ActionResult<List<string>> GetAllPlayers()
        {
            return Ok();
        }
    }
}