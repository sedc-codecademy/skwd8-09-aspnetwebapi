using SEDC.NoteApp.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SEDC.NoteApp.DataAccess.ADONET
{
    public class NoteRepositoryADO : IRepository<NoteDTO>
    {
        private readonly string _connectionString;
        public NoteRepositoryADO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(NoteDTO entity)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            // GOOD EXAMPLE
            cmd.CommandText = $@"INSERT INTO Notes (Text, Color, Tag, UserId) 
VALUES(@noteText, @noteColor, @noteTag, @noteUserId)";
            cmd.Parameters.AddWithValue("@noteText", $"{entity.Text}");
            cmd.Parameters.AddWithValue("@noteColor", $"{entity.Color}");
            cmd.Parameters.AddWithValue("@noteTag", entity.Tag);
            cmd.Parameters.AddWithValue("@noteUserId", entity.UserId);

            // BAD EXAMPLE
            /*
            cmd.CommandText = $@"INSERT INTO Notes (Text, Color, Tag, UserId) 
VALUES('{entity.Text}', '{entity.Color}', {entity.Tag}, {entity.UserId});";
            */
            // SQL INJECTION
            // if ' OR 1 = 1 ---------------> All data from table
            // if ' DROP TABLE dbo.Notes ---> Will drop the Notes table

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void Delete(NoteDTO entity)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = $"DELETE FROM Notes WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public IEnumerable<NoteDTO> GetAll()
        {
            // 1. Create new connection and give it a connection string
            SqlConnection connection = new SqlConnection(_connectionString);
            // 2. Open the connection to the database
            connection.Open();
            // 3. Create new SQL Command
            SqlCommand cmd = new SqlCommand();
            // 4. Give the command a connetion to some database
            cmd.Connection = connection;
            // 5. Write the SQL query
            cmd.CommandText = "SELECT * FROM Notes";

            // 6. A Data Reader that sequentially reads data from a data source ( table in our example )
            SqlDataReader dr = cmd.ExecuteReader();

            // 7. Preparing the result variable where we will keep all the notes
            List<NoteDTO> notes = new List<NoteDTO>();

            // 8. We go through each row of the table with dr.Read()
            // Note: dr.Read() lists all items and returns true or false wether there are more items or not
            while (dr.Read())
            {
                // 9. We add the information from the columns in to an Object and inside the list of notes
                // There are multiple approaches of getting data from a data reader source

                // Approach 1
                //notes.Add(new NoteDTO()
                //{
                //    Id = dr.GetInt32(0),
                //    Text = dr.GetString(1),
                //    Color = dr.GetString(2),
                //    Tag = dr.GetInt32(3),
                //    UserId = dr.GetInt32(4)
                //});

                // Approach 2
                //notes.Add(new NoteDTO()
                //{
                //    Id = dr.GetFieldValue<int>(0),
                //    Text = dr.GetFieldValue<string>(1),
                //    Color = dr.GetFieldValue<string>(2),
                //    Tag = dr.GetFieldValue<int>(3),
                //    UserId = dr.GetFieldValue<int>(4)
                //});

                // Approach 3
                notes.Add(new NoteDTO()
                {
                    Id = (int)dr["Id"],
                    Text = (string)dr["Text"],
                    Color = (string)dr["Color"],
                    Tag = (int)dr["Tag"],
                    UserId = (int)dr["UserId"]
                });
            }

            // 10. Last step is to close the connection since we got everything we need
            connection.Close();

            return notes;
        }

        public NoteDTO GetById(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = $"SELECT * FROM Notes WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dr = cmd.ExecuteReader();
            NoteDTO note = new NoteDTO();

            while (dr.Read())
            {
                note = new NoteDTO
                {
                    Id = dr.GetFieldValue<int>(0),
                    Text = dr.GetFieldValue<string>(1),
                    Color = dr.GetFieldValue<string>(2),
                    Tag = dr.GetFieldValue<int>(3),
                    UserId = dr.GetFieldValue<int>(4)
                };
            }
            connection.Close();
            return note;
        }

        public void Update(NoteDTO update)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = $@"UPDATE Notes SET Text = @noteText, Color= @noteColor, Tag = @noteTag, UserId= @noteUserId
WHERE Id = @noteId";
            cmd.Parameters.AddWithValue("@noteText", update.Text);
            cmd.Parameters.AddWithValue("@noteColor", update.Color);
            cmd.Parameters.AddWithValue("@noteTag", update.Tag);
            cmd.Parameters.AddWithValue("@noteUserId", update.UserId);
            cmd.Parameters.AddWithValue("@noteId", update.Id);
            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
