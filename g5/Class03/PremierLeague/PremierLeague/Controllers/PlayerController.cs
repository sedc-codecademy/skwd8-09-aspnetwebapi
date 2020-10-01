using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PremierLeague.Models;

namespace PremierLeague.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Player>> GetAll()
        {
            return StaticDb.Players;
        }
    }
}
