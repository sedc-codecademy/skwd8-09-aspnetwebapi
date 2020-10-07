using Microsoft.EntityFrameworkCore;
using StickyNotes.DataAccess.Domain;
using System.Collections.Generic;
using System.Linq;

namespace StickyNotes.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StickyNotesContext _context;

        public UserRepository(StickyNotesContext context)
        {
            _context = context;
        }

        public void Add(User entity)
        {
            _context.Add(entity);
        }

        public void Delete(User entity)
        {
            _context.Remove(entity);
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> users = _context.Set<User>()
                .Include(u => u.Notes)
                .ToList();

            return users;
        }

        public User GetById(int id)
        {
            User user = _context.Set<User>()
                .Include(u => u.Notes)
                .Single(u => u.Id == id);

            return user;
        }

        public void Update(User entity)
        {
            User user = _context.Find<User>(entity.Id);

            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;
            user.Username = entity.Username;
            user.Password = entity.Password;
            user.Notes = entity.Notes;

            _context.Update(user);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
