using AutoMapper;
using StickyNotes.DataAccess.Domain;
using StickyNotes.DataAccess.Repositories;
using StickyNotes.PresentationLayer.Responses;
using StickyNotes.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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
    }
}
