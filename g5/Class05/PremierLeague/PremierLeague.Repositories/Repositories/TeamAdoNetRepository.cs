using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;
using PremierLeague.DataAccess.PremierLeague.DataAccess.DbAccess;
using PremierLeague.Repositories.Interfaces;

namespace PremierLeague.Repositories.Repositories
{
    public class TeamAdoNetRepository : IRepository<Team>
    {
        public IEnumerable<Team> GetAll()
        {
            SqlConnection connection = new SqlConnection("Server=.;Database=PremierLeague.Database;Trusted_Connection=True;");

            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            //command.CommandText = @"SELECT [Id]
            //    ,[Name]
            //    ,[Country]
            //    ,[City]
            //    ,[TitlesWon]
            //    ,[CoachID]
            //FROM [Team]";
            command.CommandText = @"SELECT t.*, c.*
            FROM [Team] t
            INNER JOIN Coach c ON t.CoachID = c.Id";

            SqlDataReader reader = command.ExecuteReader();
            var teams = new List<Team>();
            while (reader.Read())
            {
                //int id = reader.GetInt32(0);
                //string name = reader.GetString(1);
                //string country = reader.GetString(2);
                //string city = reader.GetString(3);
                //int titles = reader.GetInt32(4);
                //int coachId = reader.GetInt32(5);

                //var team = new Team()
                //{
                //    Id = id,
                //    Name = name,
                //    Country = country,
                //    City = city,
                //    TitlesWon = titles,
                //    CoachId = coachId
                //};

                var team = new Team();
                team.Id = reader.GetInt32(0);
                //team.Name = reader.GetString(1);
                //team.Name = (string)reader["Name"];
                team.Name = reader.GetFieldValue<string>(1);
                team.Country = reader.GetString(2);
                team.City = reader.GetString(3);
                team.TitlesWon = reader.GetInt32(4);
                team.CoachId = reader.GetInt32(5);

                var coach = new Coach();
                coach.Id = reader.GetInt32(6);
                coach.FirstName = reader.GetString(7);
                coach.LastName = reader.GetString(8);
                coach.Age = reader.GetInt32(9);

                team.CoachNavigation = coach;

                teams.Add(team);
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
