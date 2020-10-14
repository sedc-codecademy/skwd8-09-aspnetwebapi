using SEDC.NoteApp.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SEDC.NoteApp.DataAccess.ADONET
{
    public class UserRepositoryADO : IRepository<UserDTO>
    {
        private readonly string _connectionString;
        public UserRepositoryADO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(UserDTO entity)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            // BAD EXAMPLE - SQL Injection
            //cmd.CommandText = $@"INSERT INTO Users(Username, Password, FirstName, LastName)
            //                     VALUES('{entity.Username}', '{entity.Password}', '{entity.FirstName}', '{entity.LastName}')
            //                    ";


            // GOOD EXAMPLE
            cmd.CommandText = $@"INSERT INTO Users(Username, Password, FirstName, LastName)
                                 VALUES(@userUserName, @userPassword, @userFirstName, @userLastName)
                                ";
            cmd.Parameters.AddWithValue("@userUserName", entity.Username);
            cmd.Parameters.AddWithValue("@userPassword", entity.Password);
            cmd.Parameters.AddWithValue("@userFirstName", entity.FirstName);
            cmd.Parameters.AddWithValue("@userLastName", entity.LastName);

            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(UserDTO entity)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connection;
            cmd.CommandText = $"DELETE FROM Users WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", entity.Id);

            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "SELECT * FROM Users";

            SqlDataReader dr = cmd.ExecuteReader();

            List<UserDTO> users = new List<UserDTO>();

            while (dr.Read())
            {
                users.Add(new UserDTO()
                {
                    Id = dr.GetFieldValue<int>(0),
                    Username = dr.GetFieldValue<string>(1),
                    Password = dr.GetFieldValue<string>(2),
                    FirstName = dr.GetFieldValue<string>(3),
                    LastName = dr.GetFieldValue<string>(4)
                });
            }
            connection.Close();
            return users;
        }

        public UserDTO GetById(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = $"SELECT * FROM Users WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dr = cmd.ExecuteReader();
            UserDTO user = new UserDTO();

            while (dr.Read())
            {
                user = new UserDTO
                {
                    Id = dr.GetFieldValue<int>(0),
                    Username = dr.GetFieldValue<string>(1),
                    Password = dr.GetFieldValue<string>(2),
                    FirstName = dr.GetFieldValue<string>(3),
                    LastName = dr.GetFieldValue<string>(4)
                };
            }
            connection.Close();
            return user;
        }

        public void Update(UserDTO entity)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = $@"UPDATE Users SET Username = @userUserName, 
                                                  Password = @userPassword, 
                                                  FirstName = @userFirstName, 
                                                  LastName = @userLastName";

            cmd.Parameters.AddWithValue("@userUserName", entity.Username);
            cmd.Parameters.AddWithValue("@userPassword", entity.Password);
            cmd.Parameters.AddWithValue("@userFirstName", entity.FirstName);
            cmd.Parameters.AddWithValue("@userLastName", entity.LastName);
            connection.Close();
        }
    }
}
