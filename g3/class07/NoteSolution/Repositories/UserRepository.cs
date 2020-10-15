using Data;
using Models.Dto;
using Models.Entity;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NoteDbContext _context;

        public UserRepository(NoteDbContext context)
        {
            _context = context;
        }

        public IQueryable<User> GetAll()
        {
            return _context.Users.AsQueryable();
        }

        public User GetById(Guid id)
        {
            return _context.Users.SingleOrDefault(u => u.Id == id);
        }

        public User GetByUsername(string username)
        {
            return _context.Users.SingleOrDefault(u => u.Username == username);
        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public User Edit(User model)
        {
            User user = _context.Users.SingleOrDefault(u => u.Id == model.Id);
            user.Email = model.Email;
            user.Username = model.Username;
            user.Password = model.Password;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Age = model.Age;
            _context.SaveChanges();

            return user;
        }

        public int Delete(Guid id)
        {
            User user = _context.Users.Single(u => u.Id == id);
            _context.Users.Remove(user);
            return _context.SaveChanges();
        }
    }
}
