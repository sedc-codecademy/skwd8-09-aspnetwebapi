using PremierLeague.DataAccess.PremierLeague.DataAccess.DbAccess;
using PremierLeague.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PremierLeague.Repositories.Repositories
{
    public class TeamRepository : IRepository<Team>
    {
        private readonly PremierLeagueContext _dbContext;

        public TeamRepository(PremierLeagueContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Team> GetAll()
        {
            return _dbContext.Team;
        }

        public Team GetById(int id)
        {
            var team = _dbContext.Set<Team>().SingleOrDefault(x => x.Id == id);
            if (team == null)
                throw new ApplicationException("The team is not found");
            return team;
        }
        public void Add(Team entity)
        {
            _dbContext.Set<Team>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Team entity)
        {
            _dbContext.Set<Team>().Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Team entity)
        {
            _dbContext.Set<Team>().Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
