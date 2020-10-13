using Data.Interfaces;
using Domain_Models.Models;
using DTO_Models.ApiModels;
using Mappings;
using Services.Exceptions;
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
        public void AddUser(UserModel userModel)
        {
            if (string.IsNullOrEmpty(userModel.UserName))
            {
                throw new UserException(null, "UserName field is required!");
            }
            if (string.IsNullOrEmpty(userModel.Password))
            {
                throw new UserException(null, "Password field is required");
            }
            if (userModel.FirstName.Count() > 50)
            {
                throw new UserException(null, "FirstName field can not have more then 50 characters");
            }
            var user = UserMapper.UserModelToUser(userModel);
            _userRepo.Insert(user);
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user == null) throw new UserException(id, "Not valid user ID");
            _userRepo.Remove(id);
        }

        public List<UserModel> GetAllUsers()
        {
            return UserMapper.UsersToUsersModels(_userRepo.GetAll().ToList());
        }

        public UserModel GetUserById(int id)
        {
            var user = _userRepo.GetById(id);
            if (user == null) throw new UserException(id, "Invalid user ID!");
            return UserMapper.UserToUserModel(user);
        }

        public void UpdateUser(UserModel userModel)
        {
            var userCheck = _userRepo.GetById(userModel.Id);
            if (userCheck == null) throw new UserException(userModel.Id, "No such user to be updated!");
            if (string.IsNullOrEmpty(userModel.UserName))
            {
                throw new UserException(null, "UserName field is required!");
            }
            if (string.IsNullOrEmpty(userModel.Password))
            {
                throw new UserException(null, "Password field is required");
            }
            if (userModel.FirstName.Count() > 50)
            {
                throw new UserException(null, "FirstName field can not have more then 50 characters");
            }
            var user = UserMapper.UserModelToUser(userModel);
            _userRepo.Update(user);
        }
    }
}
