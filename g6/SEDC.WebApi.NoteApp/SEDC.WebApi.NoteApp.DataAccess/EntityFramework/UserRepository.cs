using Microsoft.EntityFrameworkCore;
using SEDC.WebApi.NoteApp.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.WebApi.NoteApp.DataAccess.EntityFramework
{
    public class UserRepository : IRepository<User>
    {
        private readonly NotesDbContext _context;

        public UserRepository(NotesDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public void Insert(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }
    }
}
