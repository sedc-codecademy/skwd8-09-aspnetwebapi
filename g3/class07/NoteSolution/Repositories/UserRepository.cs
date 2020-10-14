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
        private readonly NoteDbContext _dbContext;

        public UserRepository(NoteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public bool Delete(Guid id)
        {
            var user = _dbContext.Users.Where(x => x.Id == id).FirstOrDefault();

            if (user == null)
                return false;

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();

            return true;
        }

        public bool Edit(EditUserDto user)
        {
            var userModel = _dbContext.Users.FirstOrDefault(x => x.Id == user.Id);

            if (userModel == null)
                return false;

            userModel.FirstName = user.FirstName;
            userModel.LastName = user.LastName;
            userModel.Username = user.Username;
            userModel.Password = user.Password;
            userModel.Age = user.Age;

            _dbContext.Users.Update(userModel);
            _dbContext.SaveChanges();

            return true;
        }

        public User GetById(Guid id) => _dbContext.Users.FirstOrDefault(x => x.Id == id);


        public IEnumerable<User> GetUsers()
        {
            return _dbContext.Users.AsEnumerable();
        }
    }
}
