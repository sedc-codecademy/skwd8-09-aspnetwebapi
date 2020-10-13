using SEDC.NoteApp.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.NoteApp.DataAccess.EntityFramework
{
    public class UserRepository : IRepository<UserDTO>
    {
        private readonly NoteDbContext _db;
        public UserRepository(NoteDbContext db)
        {
            _db = db;
        }

        public void Add(UserDTO entity)
        {
            _db.Users.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(UserDTO entity)
        {
            _db.Users.Remove(entity);
            _db.SaveChanges();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return _db.Users;
        }

        public UserDTO GetById(int id)
        {
            return _db.Users.SingleOrDefault(x => x.Id == id);
        }

        public void Update(UserDTO entity)
        {
            _db.Users.Update(entity);
            _db.SaveChanges();
        }
    }
}
