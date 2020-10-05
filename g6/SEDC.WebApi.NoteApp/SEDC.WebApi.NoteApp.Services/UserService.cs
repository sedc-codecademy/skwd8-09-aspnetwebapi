using SEDC.WebApi.NoteApp.DataAccess;
using SEDC.WebApi.NoteApp.DataModel;
using SEDC.WebApi.NoteApp.Models;
using SEDC.WebApi.NoteApp.Services.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace SEDC.WebApi.NoteApp.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            this._userRepository = userRepository;
        }

        public void Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Register(RegisterModel request)
        {
            if (string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.ConfirmPassword))
            {
                throw new Exception();
            }

            if (request.Password != request.ConfirmPassword)
            {
                throw new Exception();
            }

            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                throw new Exception(); // should use custom exception
            }

            if (string.IsNullOrWhiteSpace(request.LastName))
            {
                throw new Exception();
            }

            if (string.IsNullOrWhiteSpace(request.Username))
            {
                throw new Exception();
            }

            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(request.Password));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Password = hashedPassword
            };

            _userRepository.Insert(user);
        }
    }
}
