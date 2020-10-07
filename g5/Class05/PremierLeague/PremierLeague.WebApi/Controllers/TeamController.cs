using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PremierLeague.PresentationLayer.Responses;
using PremierLeague.Services.Services.Interfaces;

namespace PremierLeague.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public ActionResult<List<TeamResponseModel>> GetAllTeams()
        {
            return _teamService.GetAllTeams();
        }
    }
}
