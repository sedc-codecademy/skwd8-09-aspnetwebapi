using Data.Interfaces;
using Domain_Models.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data.AdoNetRepositories
{
    public class AdoUserRepository : IRepository<User>
    {
        private readonly string _connectionString;
        public AdoUserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public ICollection<User> GetAll()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM dbo.[Users]";
            SqlDataReader dataReader = command.ExecuteReader();
            List<User> users = new List<User>();
            while(dataReader.Read())
            {
                // approach 1
                //var user = new User()
                //{
                //    Id = dataReader.GetInt32(0),
                //    FirstName = dataReader.GetString(1),
                //    LastName = dataReader.GetString(2),
                //    UserName = dataReader.GetString(3),
                //    Password = dataReader.GetString(4)
                //};

                //approach 2
                //var user = new User()
                //{
                //    Id = dataReader.GetFieldValue<int>(0),
                //    FirstName = dataReader.GetFieldValue<string>(1),
                //    LastName = dataReader.GetFieldValue<string>(2),
                //    UserName = dataReader.GetFieldValue<string>(3),
                //    Password = dataReader.GetFieldValue<string>(4)
                //};

                //approach 3
                var user = new User()
                {
                    Id = (int)dataReader["Id"],
                    FirstName = (string)dataReader["FirstName"],
                    LastName = (string)dataReader["LastName"],
                    UserName = (string)dataReader["UserName"],
                    Password = (string)dataReader["Password"]
                };
                users.Add(user);
            }
            connection.Close();
            return users;
        }

        public User GetById(int id)
        {
            User user = new User();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM dbo.[Users] WHERE Id = @id";
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader dataReader = command.ExecuteReader();
                
                if(dataReader.Read())
                {
                    user.Id = (int)dataReader["Id"];
                    user.FirstName = (string)dataReader["FirstName"];
                    user.LastName = (string)dataReader["LastName"];
                    user.UserName = (string)dataReader["UserName"];
                    user.Password = (string)dataReader["Password"];
                }         
            }
            return user;
        }

        public void Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
