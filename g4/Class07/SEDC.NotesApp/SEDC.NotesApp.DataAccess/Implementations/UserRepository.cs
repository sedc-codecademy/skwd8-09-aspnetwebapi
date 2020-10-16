using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SEDC.NotesApp.Domain;
using SEDC.NotesApp.Domain.Models;

namespace SEDC.NotesApp.DataAccess.Implementations
{
    public class UserRepository:IRepository<User>
    {
        private NotesAppDbContext _notesAppDbContext;

        public UserRepository(NotesAppDbContext notesAppDbContext)
        {
            _notesAppDbContext = notesAppDbContext;
        }
        public List<User> GetAll()
        {
            return _notesAppDbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _notesAppDbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Add(User entity)
        {
            _notesAppDbContext.Users.Add(entity);
            _notesAppDbContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
