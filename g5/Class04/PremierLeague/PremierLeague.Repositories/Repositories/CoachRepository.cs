using PremierLeague.DataAccess.PremierLeague.DataAccess.DbAccess;
using PremierLeague.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PremierLeague.Repositories.Repositories
{
    public class CoachRepository : IRepository<Coach>
    {
        private readonly PremierLeagueContext _dbcontext;
        public CoachRepository(PremierLeagueContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IEnumerable<Coach> GetAll()
        {
            return _dbcontext.Coach;
        }

        public Coach GetById(int id)
        {
            var coach = _dbcontext.Coach.SingleOrDefault(c => c.Id == id);
            if (coach == null)
                throw new ApplicationException("The coach is not found");
            return coach;
        }
        public void Add(Coach entity)
        {
            _dbcontext.Set<Coach>().Add(entity);
            _dbcontext.SaveChanges();
        }
        public void Update(Coach entity)
        {
            _dbcontext.Set<Coach>().Update(entity);
            _dbcontext.SaveChanges();
        }

        public void Delete(Coach entity)
        {
            _dbcontext.Set<Coach>().Remove(entity);
            _dbcontext.SaveChanges();
        }
    }
}
