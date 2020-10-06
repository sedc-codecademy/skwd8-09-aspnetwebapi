using PremierLeague.DataAccess.PremierLeague.DataAccess.DbAccess;
using PremierLeague.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PremierLeague.Repositories.Repositories
{
    public class CoachRepository : IRepository<Coach>
    {
        private readonly PremierLeagueContext _dbContext;

        public CoachRepository(PremierLeagueContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Coach> GetAll()
        {
            return _dbContext.Coach;
        }

        public Coach GetById(int id)
        {
            var coach = _dbContext.Coach.SingleOrDefault(c => c.Id == id);
            if (coach == null)
                throw new ApplicationException("The coach is not found");
            return coach;
        }
        public void Add(Coach entity)
        {
            _dbContext.Set<Coach>().Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(Coach entity)
        {
            _dbContext.Set<Coach>().Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Coach entity)
        {
            _dbContext.Set<Coach>().Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
