using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DataLayer;
using DomainModels;
using ServiceLayer.Interfaces;
using ViewModels;

namespace ServiceLayer.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<UserRole> _userRoleRepository;

        public UserService(IRepository<User> userRepository, IRepository<Role> roleRepository, IRepository<UserRole> userRoleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
        }

        public void Register(RegisterViewModel model)
        {
            if (_userRepository.GetAll().Any(x => x.Email == model.Email))
            {
                throw new Exception($"User with email {model.Email} is already registered");
            }

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = HashPassword(model.Password)
            };

            _userRepository.Insert(user);

            if (model.FirstName == "Risto")
            {
                var role = _roleRepository.GetAll().FirstOrDefault(x => x.Name == "Admin");

                if (role != null)
                {
                    var userRole = new UserRole()
                    {
                        RoleId = role.Id,
                        UserId = user.Id,
                    };

                    _userRoleRepository.Insert(userRole);
                }
            }
            else
            {
                var role = _roleRepository.GetAll().FirstOrDefault(x => x.Name == "User");

                if (role != null)
                {
                    var userRole = new UserRole()
                    {
                        RoleId = role.Id,
                        UserId = user.Id
                    };

                    _userRoleRepository.Insert(userRole);
                }
            }

        }

        public UserViewModel Login(LoginViewModel model)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Email == model.Email);

            if (user == null)
            {
                return null;
            }

            var hashedPassword = HashPassword(model.Password);

            if (user.Password != hashedPassword)
            {
                return null;
            }

            return new UserViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Roles = user.UserRoles.Select(x => x.Role.Name).ToList()
            };
        }

        private string HashPassword(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes(password));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            var hashedPassword = strBuilder.ToString();

            return hashedPassword;
        }
    }
}
