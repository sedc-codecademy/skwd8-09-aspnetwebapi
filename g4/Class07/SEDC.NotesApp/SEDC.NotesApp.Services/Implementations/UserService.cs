using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Internal;
using SEDC.NotesApp.DataAccess;
using SEDC.NotesApp.Domain.Models;
using SEDC.NotesApp.Models;
using SEDC.NotesApp.Services.Interfaces;
using SEDC.NotesApp.Shared.Exceptions;

namespace SEDC.NotesApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public void RegisterUser(RegisterModel registerModel)
        {
            if (string.IsNullOrEmpty(registerModel.Username))
            {
                throw new UserException("Username is required field!");
            }
            if (registerModel.Username.Length > 50)
            {
                throw new UserException("Username can not contain more than 50 characters!");
            }
            if (!ValidateUniqueUsername(registerModel.Username))
            {
                throw new UserException("User with this username already exists!");
            }
            //to-do length FirstName, LastName
            if (registerModel.Password != registerModel.ConfirmedPassword)
            {
                throw new UserException("The passwords do not match");
            }
            if (!ValidatePassword(registerModel.Password))
            {
                throw new UserException("The password is weak!");
            }
            //use MD5 hash algorithm
            MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
            //get the bytes from the entered password ---- test(string) = 1561
            byte[] passwordBytes = Encoding.ASCII.GetBytes(registerModel.Password);
            //get the bytes from the hashed password string
            byte[] md5Bytes = md5CryptoServiceProvider.ComputeHash(passwordBytes);
            //get the hashed string from the bytes ---- 1342 == t1rf (string)
            string hashedPassword = Encoding.ASCII.GetString(md5Bytes);

            User newUser = new User
            {
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                Username = registerModel.Username,
                Password = hashedPassword
            };
            _userRepository.Add(newUser);
        }

        public string LoginUser(LoginModel loginModel)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(loginModel.Password));
            string hashedPassword = Encoding.ASCII.GetString(md5data);

            User userDb = _userRepository.GetAll().FirstOrDefault(x => x.Username == loginModel.Username
                                                                       && loginModel.Password == hashedPassword);
            if(userDb == null)
                throw new NotFoundException($"The userId with ");

            //to-do
            return null;
        }


        private bool ValidateUniqueUsername(string username)
        {
            return _userRepository.GetAll().Any(x => x.Username == username) == false;
        }

        private bool ValidatePassword(string password)
        {
            Regex passwordRegex = new Regex("^(?=.*[0-9])(?=.*[a-z]).{6,20}$");
            Match passwordMatch = passwordRegex.Match(password);
            return passwordMatch.Success;
        }
    }
}
