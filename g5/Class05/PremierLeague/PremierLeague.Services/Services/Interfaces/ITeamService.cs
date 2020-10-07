using PremierLeague.PresentationLayer.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace PremierLeague.Services.Services.Interfaces
{
    public interface ITeamService
    {
        List<TeamResponseModel> GetAllTeams();
        List<TeamResponseModel> GetTeamsByMostWins();
        TeamResponseModel GetTeamWithMostPlayers();
        void AddTeam(TeamResponseModel model);
        void UpdateTeam(TeamResponseModel model);
        void DeleteTeam(TeamResponseModel model);
    }
}
