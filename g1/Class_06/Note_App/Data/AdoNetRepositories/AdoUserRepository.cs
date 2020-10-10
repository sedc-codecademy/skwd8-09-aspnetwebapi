using Data.Interfaces;
using Domain_Models.Enums;
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
            dataReader.Close();
            command.CommandText = "SELECT * FROM dbo.[Notes]";
            var notesDataReader = command.ExecuteReader();
            List<Note> notes = new List<Note>();
            while(notesDataReader.Read())
            {
                var note = new Note()
                {
                    Id = notesDataReader.GetFieldValue<int>(0),
                    Text = notesDataReader.GetFieldValue<string>(1),
                    Color = notesDataReader.GetFieldValue<string>(2),
                    Tag = notesDataReader.GetFieldValue<TagType>(3),
                    UserId = notesDataReader.GetFieldValue<int>(4)
                };
                notes.Add(note);
            }
            foreach (var user in users)
            {
                foreach (var note in notes)
                {
                    if (user.Id == note.UserId)
                        user.Notes.Add(note);
                }
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

                if (dataReader.Read())
                {
                    user.Id = (int)dataReader["Id"];
                    user.FirstName = (string)dataReader["FirstName"];
                    user.LastName = (string)dataReader["LastName"];
                    user.UserName = (string)dataReader["UserName"];
                    user.Password = (string)dataReader["Password"];
                }
                else throw new Exception("not valid user Id");
                dataReader.Close();
                command.CommandText = "Select * From dbo.[Notes] WHERE UserId = @id";
                using(SqlDataReader notesDataReader = command.ExecuteReader())
                {
                    while (notesDataReader.Read())
                    {
                        var note = new Note()
                        {
                            Id = notesDataReader.GetFieldValue<int>(0),
                            Text = notesDataReader.GetFieldValue<string>(1),
                            Color = notesDataReader.GetFieldValue<string>(2),
                            Tag = notesDataReader.GetFieldValue<TagType>(3),
                            UserId = notesDataReader.GetFieldValue<int>(4)
                        };
                        user.Notes.Add(note);
                    }
                }
            }
            return user;
        }

        public void Insert(User entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    // BAD WAY TO DO IT

                    //command.CommandText = $"INSERT INTO dbo.[Users](FirstName, LastName, UserName, Password)" +
                    //        $" VALUES({entity.FirstName}, {entity.LastName}, {entity.UserName}, {entity.Password})";

                    command.CommandText = $"INSERT INTO dbo.[Users](FirstName, LastName, UserName, Password)" +
                        $"VALUES(@userFirstName, @userLastName, @userUserName, @userPasswod)";
                    command.Parameters.AddWithValue("@userFirstName", entity.FirstName);
                    command.Parameters.AddWithValue("@userLastName", entity.LastName);
                    command.Parameters.AddWithValue("@userUserName", entity.UserName);
                    command.Parameters.AddWithValue("@userPassword", entity.Password);
                    command.ExecuteNonQuery();
                }
                
            }
        }

        public void Remove(int id)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM dbo.[Users] Where Id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(User entity)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE dbo.[Users]" +
                        " SET FirstName = @userFirstName, LastName = @userLastName, UserName = @userUserName" +
                        " Password = @userPassword WHERE Id = @id";
                    command.Parameters.AddWithValue("@userFirstName", entity.FirstName);
                    command.Parameters.AddWithValue("@userLastName", entity.LastName);
                    command.Parameters.AddWithValue("@userUserName", entity.UserName);
                    command.Parameters.AddWithValue("@userPassword", entity.Password);
                    command.Parameters.AddWithValue("@id", entity.Id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
