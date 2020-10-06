using PremierLeague.DataAccess.PremierLeague.DataAccess.DbAccess;
using PremierLeague.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace PremierLeague.Repositories.Repositories
{
    public class PlayerRepository : IRepository<Player>
    {
        private readonly PremierLeagueContext _dbContext;
        public PlayerRepository(PremierLeagueContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Player> GetAll()
        {
            return _dbContext.Player;
        }

        public Player GetById(int id)
        {
            var player = _dbContext.Set<Player>().Find(id);
            if (player == null)
            {
                throw new ApplicationException("The player is not found");
            }
            return player;
        }
        public void Add(Player entity)
        {
            _dbContext.Set<Player>().Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(Player entity)
        {
            _dbContext.Set<Player>().Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Player entity)
        {
            _dbContext.Set<Player>().Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
