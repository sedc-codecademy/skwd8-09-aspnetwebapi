using StickyNotes.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StickyNotes.ADO.Example
{
    class Program
    {
        private static string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=StickyNotes.Database;Trusted_Connection=True;";
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = connection;
            cmd.CommandText = $"select * from [User] where FirstName Like '%'+@userName+'%'";
            cmd.Parameters.AddWithValue("@userName", "Name");

            SqlDataReader reader = cmd.ExecuteReader();

            List<User> users = new List<User>();

            while (reader.Read())
            {
                users.Add(new User
                {
                    Id = (int)reader["Id"],
                    CreatedOn = (DateTime)reader["CreatedOn"],
                    DeletedOn = null,
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Username = (string)reader["Username"],
                    Password = (string)reader["Password"]
                });
            }

            foreach (User user in users)
            {
                Console.WriteLine(user.FirstName);
            }

            connection.Close();
        }
    }
}
