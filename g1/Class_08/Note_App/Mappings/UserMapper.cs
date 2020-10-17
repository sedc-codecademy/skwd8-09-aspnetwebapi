using Domain_Models.Models;
using DTO_Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mappings
{
    public static class UserMapper
    {
        public static UserModel UserToUserModel(User user)
        {
            return new UserModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                UserName = user.UserName,
                Notes = NoteMapper.NotesToNotesModels(user.Notes.ToList())
            };
        }
        public static User UserModelToUser(UserModel user)
        {
            return new User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                UserName = user.UserName,
                Notes = NoteMapper.NotesModelsToNotes(user.Notes.ToList())
            };
        }

        public static List<UserModel> UsersToUsersModels(List<User> users)
        {
            return users.Select(user => new UserModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                UserName = user.UserName,
                Notes = NoteMapper.NotesToNotesModels(user.Notes.ToList())
            }).ToList();
        }
        public static List<User> UsersModelsToUsers(List<UserModel> users)
        {
            return users.Select(user => new User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                UserName = user.UserName,
                Notes = NoteMapper.NotesModelsToNotes(user.Notes.ToList())
            }).ToList();
        }
    }
}
