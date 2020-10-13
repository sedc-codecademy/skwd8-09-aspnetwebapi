using Data.Interfaces;
using Domain_Models.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.ServicesImplementations
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepo;
        public UserService(IRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }
        public void AddUser(User user)
        {
            _userRepo.Insert(user);
        }

        public void DeleteUser(int id)
        {
            _userRepo.Remove(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAll().ToList();
        }

        public User GetUserById(int id)
        {
            return _userRepo.GetById(id);
        }

        public void UpdateUser(User user)
        {
            _userRepo.Update(user);
        }
    }
}
