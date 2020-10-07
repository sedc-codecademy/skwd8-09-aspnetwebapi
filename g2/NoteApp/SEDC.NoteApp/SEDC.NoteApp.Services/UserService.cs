using SEDC.NoteApp.DataAccess;
using SEDC.NoteApp.DataModels;
using SEDC.NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SEDC.NoteApp.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserDTO> _userRepository;
        public UserService(IRepository<UserDTO> userRepository)
        {
            _userRepository = userRepository;
        }

        public void Register(RegisterModel model)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(model.Password));
            var hasshedPassword = Encoding.ASCII.GetString(md5data);

            var user = new UserDTO
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.UserName,
                Password = hasshedPassword
            };

            _userRepository.Add(user);
        }
    }
}
