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
            //SqlConnection connection = new SqlConnection(_connectionString);

            //connection.Open();

            //SqlCommand cmd = new SqlCommand();

            //cmd.Connection = connection;
            //cmd.CommandText = $"select * from [User] where FirstName Like '%'+@userName+'%'";
            //cmd.Parameters.AddWithValue("@userName", "Name");

            //SqlDataReader reader = cmd.ExecuteReader();

            //List<User> users = new List<User>();

            //while (reader.Read())
            //{
            //    users.Add(new User
            //    {
            //        Id = (int)reader["Id"],
            //        CreatedOn = (DateTime)reader["CreatedOn"],
            //        DeletedOn = null,
            //        FirstName = (string)reader["FirstName"],
            //        LastName = (string)reader["LastName"],
            //        Username = (string)reader["Username"],
            //        Password = (string)reader["Password"]
            //    });
            //}

            //foreach (User user in users)
            //{
            //    Console.WriteLine(user.FirstName);
            //}

            //connection.Close();
            StoredProcedre();
            Console.ReadLine();
        }

        private static void StoredProcedre()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            Console.WriteLine("Please enter username: ");
            string query = Console.ReadLine();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            //We need to set up the type of the command in order to tell ADO.NET what to execute in the db.
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //We need to insert the name of the procedure
            cmd.CommandText = "getUsers";
            //We insert the parametars that we will need to exec this stored procedure
            cmd.Parameters.AddWithValue("@username", query);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string firstName = (string)dr["FirstName"];
                string lastName = (string)dr["LastName"];

                Console.WriteLine($" FirstName:  {firstName} --  LastName: {lastName}");
            }

            connection.Close();
        }
    }
}
