using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using StickyNotes.API.Models;
using StickyNotes.DataAccess.Domain;
using StickyNotes.DataAccess.Repositories;
using StickyNotes.PresentationLayer.Responses;
using StickyNotes.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace StickyNotes.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,INoteRepository notesRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _noteRepository = notesRepository;
            _mapper = mapper;
        }

        #region Old methods

        public List<GetUserResponse> GetAllUsers()
        {
            var users = _userRepository.GetAll().ToList();
            var usersResponse = _mapper.Map<List<User>, List<GetUserResponse>>(users);
            return usersResponse;
        }

        public GetUserResponse GetById(int id)
        {
            var user = _userRepository.GetById(id);
            var userResponse = Mapper.Map<User, GetUserResponse>(user);
            return userResponse;
        }

        public List<GetUserResponse> GetUserswithSameUsernameLength(int length)
        {
            var users = _userRepository.GetAll().Where(u => u.Username.Length == length).ToList();
            var usersResponse = Mapper.Map<List<User>, List<GetUserResponse>>(users);
            return usersResponse;
        }

        public void CreateUser(GetUserResponse userResponse)
        {
            var user = Mapper.Map<GetUserResponse, User>(userResponse);
            _userRepository.Add(user);
            _userRepository.Save();
        }
        public void UpdateUser(GetUserResponse userResponse)
        {
            var user = Mapper.Map<GetUserResponse, User>(userResponse);
            _userRepository.Update(user);
            _userRepository.Save();
        }
        public void DeleteUser(GetUserResponse userResponse)
        {
            var user = Mapper.Map<GetUserResponse, User>(userResponse);
            if (user == null)
            {
                throw new ApplicationException("The user does not exist therefor you can not delete it");
            }
            _userRepository.Delete(user);
            _userRepository.Save();
        }

        #endregion


        #region Auth

        public GetUserResponse Authenticate(string username, string password)
        {
            var hashedPassword = HashPassword(password);

            var user = _userRepository
                .GetAll()
                .SingleOrDefault(u => u.Username == username && u.Password == hashedPassword);

            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = Encoding.ASCII.GetBytes("Random string, that we will use as our secret");
            var tokenDesriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secret),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDesriptor);

            GetUserResponse userResponse = new GetUserResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Password = null,
                CreatedOn = user.CreatedOn,
                Notes = null,
                Token = token
            };

            return userResponse;
        }

        public GetUserResponse Register(CreateUserRequest request)
        {

            var hashedPassword = HashPassword(request.Password);

            var requestWithHash = new CreateUserRequest
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Password = hashedPassword
            };

            var user = _mapper.Map<CreateUserRequest, User>(requestWithHash);

            _userRepository.Add(user);
            _userRepository.Save();

            GetUserResponse userResponse = new GetUserResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Password = null,
                CreatedOn = user.CreatedOn,
                Notes = null,
                Token = null
            };

            return userResponse;
        }

        private string HashPassword(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5Data = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Encoding.ASCII.GetString(md5Data);
        }

        #endregion
    }
}
