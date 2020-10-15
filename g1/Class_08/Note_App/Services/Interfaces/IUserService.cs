using Domain_Models.Models;
using DTO_Models;
using DTO_Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IUserService
    {
        List<UserModel> GetAllUsers();
        UserModel GetUserById(int id);
        void AddUser(RegisterModel user);
        void UpdateUser(UserModel user);
        void DeleteUser(int id);
        UserModel Authenticate(LoginModel user);
    }
}
