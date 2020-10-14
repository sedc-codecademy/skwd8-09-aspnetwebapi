using Dapper;
using Dapper.Contrib.Extensions;
using Data.Interfaces;
using Domain_Models.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Data.DapperRepositories
{
    public class DapperUserRepository : IRepository<User>
    {
        private readonly string _connectionString;
        public DapperUserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public ICollection<User> GetAll()
        {
            var users = new List<User>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // returns all users without their notes

                //var users = connection.Query<User>("Select * from dbo.[Users]").ToList();
                
                var notes = new List<Note>();
                using(var multi = connection.QueryMultiple("SELECT * from dbo.[Users]; Select * From dbo.[Notes]"))
                {
                    users = multi.Read<User>().ToList();
                    notes = multi.Read<Note>().ToList();
                }
                foreach (var user in users)
                {
                    foreach (var note in notes)
                    {
                        if (user.Id == note.UserId)
                            user.Notes.Add(note);
                    }
                }
            }
            return users;
        }

        public User GetById(int id)
        {
            var user = new User();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var multi = connection
                    .QueryMultiple("Select * From dbo.[Users] Where Id = @Id;" +
                    " SELECT * FROM dbo.[Notes] Where UserId = @Id", new { Id = id }))
                {
                    user = multi.Read<User>().Single();
                    var notes = multi.Read<Note>().ToList();
                    foreach (var note in notes)
                    {
                        user.Notes.Add(note);
                    }
                    // user.Notes = multi.Read<Note>().ToList();
                }
            }
            return user;
        }

        public void Insert(User entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Insert(entity);
            }
        }

        public void Remove(int id)
        {
            var user = GetById(id);
            if (user == null) throw new Exception("invalid user id");
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Delete(user);
            }
        }

        public void Update(User entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Update(entity);
            }
        }
    }
}
