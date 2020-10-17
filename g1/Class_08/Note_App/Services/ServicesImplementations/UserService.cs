using Data.Interfaces;
using Domain_Models.Models;
using DTO_Models;
using DTO_Models.ApiModels;
using DTO_Models.SettingsModels;
using Mappings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Exceptions;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Services.ServicesImplementations
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepo;
        private IOptions<JwtSettings> _jwtSettings;
        public UserService(IRepository<User> userRepo, IOptions<JwtSettings> jwtSettings)
        {
            _userRepo = userRepo;
            _jwtSettings = jwtSettings;
        }

        public void AddUser(RegisterModel user)
        {
            if (string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.ConfirmPassword))
            {
                throw new UserException(null, "Password is required");
            }
            if (user.Password != user.ConfirmPassword)
            {
                throw new UserException(null, "Passwords does not match!");
            }
            if (string.IsNullOrEmpty(user.FirstName))
            {
                throw new UserException(null, "username field is required!");
            }
            if (user.FirstName.Count() > 50)
            {
                throw new UserException(null, "firstname field can not have more then 50 characters");
            }

            var userToRegister = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                UserName = user.UserName
            };
            _userRepo.Insert(userToRegister);

        }

        public UserModel Authenticate(LoginModel userModel)
        {
            var user = _userRepo.GetAll().SingleOrDefault(u => u.UserName == userModel.UserName && u.Password == userModel.Password);
            if (user == null)
                throw new UserException(null, "UserName and passowrd dont match!");
            var token = GenerateJwtToken(user);
            var userModelToReturn = new UserModel
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Token = token
            };
            return userModelToReturn;

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

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var seacret = Encoding.ASCII.GetBytes(_jwtSettings.Value.Seacret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(_jwtSettings.Value.ExpireDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(seacret), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
