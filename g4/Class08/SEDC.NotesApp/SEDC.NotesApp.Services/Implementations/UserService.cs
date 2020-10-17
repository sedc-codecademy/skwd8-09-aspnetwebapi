using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SEDC.NotesApp.DataAccess;
using SEDC.NotesApp.Domain.Models;
using SEDC.NotesApp.Models;
using SEDC.NotesApp.Services.Interfaces;
using SEDC.NotesApp.Shared;
using SEDC.NotesApp.Shared.Exceptions;

namespace SEDC.NotesApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;
        //IOptions is used to retrieve the configuration - in this case the AppSettings Configuration Section
        private IOptions<AppSettings> _options;

        public UserService(IRepository<User> userRepository, IOptions<AppSettings> options)
        {
            _userRepository = userRepository;
            _options = options;
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
                                                                       && x.Password == hashedPassword);
            if(userDb == null)
                throw new NotFoundException($"The user with username {loginModel.Username} was not found! ");
            //authentication (identification of user) finished

            //Install System.IdentityModel.Tokens.Jwt 5.2.2 NuGet

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            //string secretKey = "Notes app secret secret key";
            //get the SecretKey from AppSettings
            byte[] secretKeyBytes = Encoding.ASCII.GetBytes(_options.Value.SecretKey);
                //configure the token
                SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddDays(7),
                    //signature definition
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes),
                        SecurityAlgorithms.HmacSha256Signature),
                    //payload
                    Subject = new ClaimsIdentity(
                        new[]
                        {
                            new Claim(ClaimTypes.Name, userDb.Username),
                            new Claim(ClaimTypes.NameIdentifier, userDb.Id.ToString()),
                            new Claim("userFullName", $"{userDb.FirstName} {userDb.LastName}"),
                        }
                    )
                };
                SecurityToken token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
                return jwtSecurityTokenHandler.WriteToken(token);
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
