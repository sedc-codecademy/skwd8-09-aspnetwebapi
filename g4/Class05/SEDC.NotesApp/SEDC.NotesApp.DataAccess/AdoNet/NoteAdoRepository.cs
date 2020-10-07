using SEDC.NotesApp.Domain.Enums;
using SEDC.NotesApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SEDC.NotesApp.DataAccess.AdoNet
{
    public class NoteAdoRepository : IRepository<Note>
    {
        private string _connectionString;
        public NoteAdoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Note entity)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = $@"INSERT INTO Notes (Text, Color, Tag, UserId) 
                                             VALUES(@noteText, @noteColor, @noteTag, @noteUserId)";
            cmd.Parameters.AddWithValue("@noteText", entity.Text);
            cmd.Parameters.AddWithValue("@noteColor", entity.Color);
            cmd.Parameters.AddWithValue("@noteTag", entity.Tag);
            cmd.Parameters.AddWithValue("@noteUserId", entity.UserId);

            // BAD EXAMPLE - potential sql injection attack
            /*
            cmd.CommandText = $@"INSERT INTO Notes (Text, Color, Tag, UserId) 
VALUES('{entity.Text}', '{entity.Color}', {entity.Tag}, {entity.UserId});";
            */

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = $"DELETE FROM Notes WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public List<Note> GetAll()
        {
            // using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            //{
            //    sqlConnection.Open();
            //}
            // 1. Create new connection and give it a connection string
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            // 2. Open the connection to the database
            sqlConnection.Open();
            // 3. Create new SQL Command
            SqlCommand command = new SqlCommand();
            // 4. Give the command a connetion to the database
            command.Connection = sqlConnection;
            // 5. Write the SQL query
            command.CommandText = "SELECT * FROM dbo.Notes";

            List<Note> notesDb = new List<Note>();
            // 6. A Data Reader that sequentially reads data from a data source ( Notes table in our example )
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                notesDb.Add(new Note
                {
                    Id = (int)reader["Id"],
                    Text = (string)reader["Text"],
                    Color = (string)reader["Color"],
                    Tag = (TagType)reader["Tag"],
                    UserId = (int)reader["UserId"]
                });
            }
            sqlConnection.Close();
            return notesDb;
        }

        public Note GetById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            // command.CommandText = $"SELECT * FROM dbo.Notes WHERE Id = {id}"; - bad example
            command.CommandText = $"SELECT * FROM dbo.Notes WHERE Id = @id"; //'id'
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = command.ExecuteReader();

            List<Note> notesDb = new List<Note>();
           // Note noteDb = null;
            while (reader.Read())
            {
                //notesDb = new Note
                //{
                //    Id = (int)reader["Id"],
                //    Text = (string)reader["Text"],
                //    Color = (string)reader["Color"],
                //    Tag = (TagType)reader["Tag"],
                //    UserId = (int)reader["UserId"]
                //};
                notesDb.Add(new Note
                {
                    Id = (int)reader["Id"],
                    Text = (string)reader["Text"],
                    Color = (string)reader["Color"],
                    Tag = (TagType)reader["Tag"],
                    UserId = (int)reader["UserId"]
                });
            }
            sqlConnection.Close();
            return notesDb.FirstOrDefault();
        }

        public void Update(Note entity)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = $@"UPDATE dbo.Notes SET Text = @noteText, Color= @noteColor, Tag = @noteTag, UserId= @noteUserId
                                            WHERE Id = @noteId";
            cmd.Parameters.AddWithValue("@noteText", entity.Text);
            cmd.Parameters.AddWithValue("@noteColor", entity.Color);
            cmd.Parameters.AddWithValue("@noteTag", entity.Tag);
            cmd.Parameters.AddWithValue("@noteUserId", entity.UserId);
            cmd.Parameters.AddWithValue("@noteId", entity.Id);
            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
