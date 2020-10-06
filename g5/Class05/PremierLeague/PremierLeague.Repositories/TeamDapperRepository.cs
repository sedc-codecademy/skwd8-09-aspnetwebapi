using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using PremierLeague.DataAccess.PremierLeague.DataAccess.DbAccess;
using PremierLeague.Repositories.Interfaces;

namespace PremierLeague.Repositories
{
    public class TeamDapperRepository : IRepository<Team>
    {
        public IEnumerable<Team> GetAll()
        {
            IDbConnection connection = new SqlConnection("Server=.;Database=PremierLeague.Database;Trusted_Connection=True;");
            connection.Open();

            //List<Team> teams = connection.Query<Team>(@"SELECT [Id]
            //    ,[Name]
            //    ,[Country]
            //    ,[City]
            //    ,[TitlesWon]
            //    ,[CoachID]
            //FROM [Team]").ToList();

            List<Team> teams = connection.Query<Team>(@"SELECT * FROM [Team]").ToList();

            foreach (var team in teams)
            {
                Coach coach = connection.QueryFirst<Coach>("Select * From Coach");
                team.CoachNavigation = coach;
            }

            connection.Close();

            return teams;
        }

        public Team GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Add(Team entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Team entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Team entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
