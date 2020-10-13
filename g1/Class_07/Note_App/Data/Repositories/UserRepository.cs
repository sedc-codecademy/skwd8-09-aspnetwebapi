using Data.DatabaseContext;
using Data.Interfaces;
using Domain_Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private NotesDbContext _context;
        public UserRepository(NotesDbContext context)
        {
            _context = context;
        }
        public ICollection<User> GetAll()
        {
            return _context.Users.Include(x => x.Notes).ToList();
        }

        public User GetById(int id)
        {
            //_context.Users.Include(x => x.Notes).SingleOrDefault(x => x.Id == id);
            return GetAll().SingleOrDefault(x => x.Id == id);
        }

        public void Insert(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var userToDelete = _context.Users.SingleOrDefault(user => user.Id == id);

            //if (userToDelete == null) return;
            //_context.Users.Remove(userToDelete);
            //_context.SaveChanges();

            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                _context.SaveChanges();
            }            
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }
    }
}
