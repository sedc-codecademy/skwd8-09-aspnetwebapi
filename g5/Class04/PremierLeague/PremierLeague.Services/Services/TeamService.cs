using PremierLeague.DataAccess.PremierLeague.DataAccess.DbAccess;
using PremierLeague.PresentationLayer.Responses;
using PremierLeague.Repositories.Interfaces;
using PremierLeague.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Text;

namespace PremierLeague.Services.Services
{
    public class TeamService : ITeamService
    {
        private IRepository<Team> _teamRepository;
        public TeamService(IRepository<Team> teamRepository)
        {
            _teamRepository = teamRepository;
        }
        public void AddTeam(TeamResponseModel model)
        {
            var originalProperty = Mapper.Map<TeamResponseModel, Team>(model);
            _teamRepository.Add(originalProperty);
        }

        public void DeleteTeam(TeamResponseModel model)
        {
            throw new NotImplementedException();
        }

        public List<TeamResponseModel> GetAllTeams()
        {
            var teams = _teamRepository.GetAll();
            var response = Mapper.Map<IEnumerable<Team>, IEnumerable<TeamResponseModel>>(teams);
            return response.ToList();
        }

        public List<TeamResponseModel> GetTeamsByMostWins()
        {
            throw new NotImplementedException();
        }

        public TeamResponseModel GetTeamWithMostPlayers()
        {
            throw new NotImplementedException();
        }

        public void UpdateTeam(TeamResponseModel model)
        {
            throw new NotImplementedException();
        }
    }
}
