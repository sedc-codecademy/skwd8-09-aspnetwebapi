using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.Configuration;
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
        private readonly TokenOptions _tokenConfig;
        private readonly MD5CryptoServiceProvider _md5;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public UserService(IUserRepository userRepository, IOptions<TokenOptions> tokenOptions)
        {
            _userRepository = userRepository;
            _tokenConfig = tokenOptions.Value;
            _md5 = new MD5CryptoServiceProvider();
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public UserWithTokenDto Authenticate(UserSignInDto model)
        {
            try
            {
                User user = _userRepository.GetByUsername(model.Username);
                ValidateSignInModel(model, user);

                byte[] key = Encoding.ASCII.GetBytes(_tokenConfig.SecretKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = _tokenHandler.CreateToken(tokenDescriptor);

                return new UserWithTokenDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Age = user.Age,
                    Token = _tokenHandler.WriteToken(token)
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Register(UserRegisterDto model)
        {
            try
            {
                ValidateUserRegisterModel(model);

                // We create the hash from the password
                byte[] md5Hash = _md5.ComputeHash(Encoding.ASCII.GetBytes(model.Password));
                // We get the hash string
                string hashedPassword = Encoding.ASCII.GetString(md5Hash);

                User user = _userRepository.Add(new User
                {
                    Id = Guid.NewGuid(),
                    Username = model.Username,
                    Email = model.Email,
                    Password = hashedPassword,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ValidateUserRegisterModel(UserRegisterDto model)
        {
            if (_userRepository.GetAll().Any(u => u.Email == model.Email))
            {
                throw new Exception($"User with {model.Email} already exists");
            }

            if (_userRepository.GetAll().Any(u => u.Username == model.Username))
            {
                throw new Exception($"User with {model.Username} already exists");
            }

            if (string.IsNullOrEmpty(model.FirstName))
            {
                throw new Exception("FirstName cannot be empty");
            }

            if (string.IsNullOrEmpty(model.LastName))
            {
                throw new Exception("LastName cannot be empty");
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                throw new Exception("Password cannot be empty");
            }

            if (!model.Password.Equals(model.ConfirmPassword))
            {
                throw new Exception("ConfirmPassword must match Password");
            }

            if (model.Age <= 0)
            {
                throw new Exception("Age must contain a value higher than 0");
            }
        }

        private void ValidateSignInModel(UserSignInDto model, User user)
        {
            byte[] md5Hash = _md5.ComputeHash(Encoding.ASCII.GetBytes(model.Password));
            string hashedPassword = Encoding.ASCII.GetString(md5Hash);
            
            if (user == null)
            {
                throw new Exception("User does not exists");
            }

            if (user.Password != hashedPassword)
            {
                throw new Exception("Wrong Password");
            }
        }
    }
}
