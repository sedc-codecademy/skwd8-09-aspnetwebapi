using PremierLeague.DataAccess.PremierLeague.DataAccess.DbAccess;
using PremierLeague.PresentationLayer.Responses;
using PremierLeague.Repositories.Interfaces;
using PremierLeague.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using System.Text;

namespace PremierLeague.Services.Services
{
    public class TeamService : ITeamService
    {
        private readonly IRepository<Team> _teamRepository;
        private readonly IMapper _mapper;

        public TeamService(IRepository<Team> teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }
        public void AddTeam(TeamResponseModel model)
        {
            var originalProperty = _mapper.Map<TeamResponseModel, Team>(model);
            _teamRepository.Add(originalProperty);
        }

        public void DeleteTeam(TeamResponseModel model)
        {
            throw new NotImplementedException();
        }

        public List<TeamResponseModel> GetAllTeams()
        {
            var teams = _teamRepository.GetAll();
            var response = _mapper.Map<IEnumerable<Team>, IEnumerable<TeamResponseModel>>(teams);
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
