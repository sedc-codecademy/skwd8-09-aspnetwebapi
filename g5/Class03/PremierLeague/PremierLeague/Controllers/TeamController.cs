using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLeague.Models;

namespace PremierLeague.Controllers
{
    /// <summary>
    /// Team Controller for managing Teams
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Team>> GetAll()
        {
            return StaticDb.Teams;
        }

        /// <summary>
        /// Endpoint for getting specific team details
        /// </summary>
        /// <remarks>
        /// Some remark
        /// </remarks>
        /// <param name="id">Team unique number</param>
        /// <returns>Team object, which contains specific team details</returns>
        [HttpGet]
        [Route("{id}")]
        public ActionResult<Team> GetById(int id)
        {
            var team = StaticDb.Teams.FirstOrDefault(x => x.Id == id);

            if (team == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"The team with id: {id} does not exist");
            }

            return team;
        }

        [HttpPost]
        public IActionResult Add(Team team)
        {
            var teamWithThatNameExists = StaticDb.Teams.Any(x =>
                string.Equals(x.Name, team.Name, StringComparison.InvariantCultureIgnoreCase));

            if (teamWithThatNameExists)
            {
                return StatusCode(StatusCodes.Status409Conflict, $"Team with name {team.Name} already exists");
            }

            var newTeam = new Team(team.Name, team.Town);
            StaticDb.Teams.Add(newTeam);

            return StatusCode(StatusCodes.Status201Created, $"Team {team.Name} is added");
        }

        //Bad example
        //[HttpPost]
        //public IActionResult Add([FromBody] string nameAndTown)
        //{
        //    var content = nameAndTown.Split(",");
        //    var name = content[0];
        //    var town = content[1];

        //    var teamWithThatNameExists = StaticDb.Teams.Any(x =>
        //        string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase));

        //    if (teamWithThatNameExists)
        //    {
        //        return StatusCode(StatusCodes.Status409Conflict, $"Team with name {name} already exists");
        //    }

        //    var newTeam = new Team(name, town);
        //    StaticDb.Teams.Add(newTeam);

        //    return StatusCode(StatusCodes.Status201Created, $"Team {name} is added");
        //}

        //[HttpPost]
        //public IActionResult Add(string name, string town)
        //{
        //    var teamWithThatNameExists = StaticDb.Teams.Any(x =>
        //        string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase));

        //    if (teamWithThatNameExists)
        //    {
        //        return StatusCode(StatusCodes.Status409Conflict, $"Team with name {name} already exists");
        //    }

        //    var newTeam = new Team(name, town);
        //    StaticDb.Teams.Add(newTeam);

        //    return StatusCode(StatusCodes.Status201Created, $"Team {name} is added");
        //}


        //[HttpPost]
        //public IActionResult Add([FromBody] string name, [FromQuery] string town)
        //{
        //    var teamWithThatNameExists = StaticDb.Teams.Any(x =>
        //        string.Equals(x.Name, name, StringComparison.InvariantCultureIgnoreCase));

        //    if (teamWithThatNameExists)
        //    {
        //        return StatusCode(StatusCodes.Status409Conflict, $"Team with name {name} already exists");
        //    }

        //    var newTeam = new Team(name, town);
        //    StaticDb.Teams.Add(newTeam);

        //    return StatusCode(StatusCodes.Status201Created, $"Team {name} is added");
        //}

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var team = StaticDb.Teams.FirstOrDefault(x => x.Id == id);

            if (team == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"The team with id: {id} does not exist");
            }

            StaticDb.Teams.Remove(team);
            return StatusCode(StatusCodes.Status200OK, "Team removed");
        }

        [HttpDelete]
        [Route("deleteByName/{name}")]
        public IActionResult Delete(string name)
        {
            var team = StaticDb.Teams.FirstOrDefault(x => x.Name == name);

            if (team == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"The team with name: {name} does not exist");
            }

            StaticDb.Teams.Remove(team);
            return StatusCode(StatusCodes.Status200OK, "Team removed");
        }
    }
}
