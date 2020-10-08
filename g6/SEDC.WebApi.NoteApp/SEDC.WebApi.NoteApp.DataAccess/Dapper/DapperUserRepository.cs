using Dapper;
using Dapper.Contrib.Extensions;
using SEDC.WebApi.NoteApp.DataModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SEDC.WebApi.NoteApp.DataAccess.Dapper
{
    public class DapperUserRepository : IRepository<User>
    {
        private readonly string _connectionString;

        public DapperUserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<User> GetAll()
        {
            using (var connection = 
                new SqlConnection(_connectionString))
            {
                connection.Open();

                var users = connection
                    .Query<User>("SELECT * FROM dbo.[Users]")
                    .ToList();

                return users;
            }
        }

        public void Insert(User entity)
        {
            using (SqlConnection connection = 
                new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Insert(entity);
            }
        }

        public void Remove(User entity)
        {
            using (SqlConnection connection = 
                new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Delete(entity);
            }
        }

        public void Update(User entity)
        {
            using (SqlConnection connection = 
                new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Update(entity);
            }
        }
    }
}
