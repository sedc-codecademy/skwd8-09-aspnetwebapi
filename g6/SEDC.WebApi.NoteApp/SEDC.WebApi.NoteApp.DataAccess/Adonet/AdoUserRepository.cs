using SEDC.WebApi.NoteApp.DataModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SEDC.WebApi.NoteApp.DataAccess.Adonet
{
    public class AdoUserRepository : IRepository<User>
    {
        private readonly string _connectionString;

        public AdoUserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<User> GetAll()
        {
            SqlConnection connection = 
                new SqlConnection(_connectionString);

            connection.Open();

            SqlCommand command = new SqlCommand();

            command.Connection = connection;

            command.CommandText = "SELECT * FROM dbo.[Users]";

            SqlDataReader dataReader = command.ExecuteReader();

            List<User> users = new List<User>();

            while (dataReader.Read())
            {
                // approach 1
                //var user = new User
                //{
                //    Id = dataReader.GetInt32(0),
                //    Username = dataReader.GetString(1),
                //    Password = dataReader.GetString(2),
                //    FirstName = dataReader.GetString(3),
                //    LastName = dataReader.GetString(4)
                //};

                // approach 2
                var user = new User
                {
                    Id = dataReader.GetFieldValue<int>(0),
                    Username = dataReader.GetFieldValue<string>(1),
                    Password = dataReader.GetFieldValue<string>(2),
                    FirstName = dataReader.GetFieldValue<string>(3),
                    LastName = dataReader.GetFieldValue<string>(4)
                };

                // approach 3
                //var user = new User
                //{
                //    Id = (int)dataReader["Id"],
                //    Username = (string)dataReader["Username"],
                //    Password = (string)dataReader["Password"],
                //    FirstName = (string)dataReader["FirstName"],
                //    LastName = (string)dataReader["LastName"]
                //};
                users.Add(user);
            }

            connection.Close();

            return users;
        }

        public void Insert(User entity)
        {
            using(SqlConnection connection = 
                new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;

                    // bad way
                    //cmd.CommandText = 
                    //    $"INSERT INTO dbo.[Users] (Username, Password, FirstName, LastName)" +
                    //    $" VALUES({entity.Username}, {entity.Password}, {entity.FirstName}, {entity.LastName})";


                    cmd.CommandText = 
                        $"INSERT INTO dbo.[Users] (Username, Password, FirstName, LastName)" +
                        $" VALUES(@userUsername, @userPassword, @userFirstName, @userLastName)";
                    cmd.Parameters.AddWithValue("@userUsername", entity.Username);
                    cmd.Parameters.AddWithValue("@userPassword", entity.Password);
                    cmd.Parameters.AddWithValue("@userFirstName", entity.FirstName);
                    cmd.Parameters.AddWithValue("@userLastName", entity.LastName);

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void Remove(User entity)
        {
            SqlConnection connection = 
                new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connection;

            cmd.CommandText = "DELETE FROM dbo.[Users] WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", entity.Id);

            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(User entity)
        {
            SqlConnection connection = 
                new SqlConnection(_connectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connection;
            cmd.CommandText = "UPDATE dbo.[Users] " +
                "SET Username = @userUsername, Password = @userPassword, FirstName = @userFirstName, LastName = @userLastName" +
                "WHERE Id = @id";
            cmd.Parameters.AddWithValue("@userUsername", entity.Username);
            cmd.Parameters.AddWithValue("@userPassword", entity.Password);
            cmd.Parameters.AddWithValue("@userFirstName", entity.FirstName);
            cmd.Parameters.AddWithValue("@userLastName", entity.LastName);
            cmd.Parameters.AddWithValue("@id", entity.Id);

            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
