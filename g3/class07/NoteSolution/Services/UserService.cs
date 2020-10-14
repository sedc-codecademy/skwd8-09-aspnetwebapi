using Microsoft.IdentityModel.Tokens;
using Models.Dto;
using Models.Entity;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public LoggedUserDto Authenticate(string userName, string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            // We create the hash from the password
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            // We get the hash string
            var hashedPassword = Encoding.ASCII.GetString(md5Data);

            var user = _userRepository.GetUsers().SingleOrDefault(x => x.Username == userName && x.Password == hashedPassword);

            if (user == null)
            {
                throw new Exception();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("SECRET! IT CAN BE ANY TEXT!");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new LoggedUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.Username,
                Token = tokenHandler.WriteToken(token)
            };
        }



        public void Register(RegisterUserDto user)
        {
            if (!CheckIfMailExists(user.Email))
            {
                throw new Exception();
            }

            if (!CheckIfUserNameExists(user.Username))
            {
                throw new Exception();
            }

            if (string.IsNullOrEmpty(user.FirstName))
            {
                throw new Exception();
            }

            if (string.IsNullOrEmpty(user.LastName))
            {
                throw new Exception();
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new Exception();
            }

            if (user.Age == 0)
            {
                throw new Exception();
            }

            if (!user.Password.Equals(user.ConfirmPassword))
            {
                throw new Exception();
            }

            var md5 = new MD5CryptoServiceProvider();
            // We create the hash from the password
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes(user.Password));
            // We get the hash string
            var hashedPassword = Encoding.ASCII.GetString(md5Data);

            var newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                Age = user.Age,
                Password = hashedPassword
            };

            _userRepository.Add(newUser);
        }

        #region private methods
        private bool CheckIfMailExists(string email)
        {
            var result = _userRepository.GetUsers().SingleOrDefault(x => x.Email == email);

            if (result == null)
            {
                return true;
            }

            return false;
        }

        private bool CheckIfUserNameExists(string userName)
        {
            var result = _userRepository.GetUsers().SingleOrDefault(x => x.Username == userName);

            if (result == null)
            {
                return true;
            }

            return false;
        }
        #endregion

    }
}
