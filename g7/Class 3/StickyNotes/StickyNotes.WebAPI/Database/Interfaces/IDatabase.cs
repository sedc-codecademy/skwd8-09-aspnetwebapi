using StickyNotes.WebAPI.Entities;
using System.Collections.Generic;

namespace StickyNotes.WebAPI.Database.Interfaces
{
    public interface IDatabase
    {
        List<User> SeedUsers(bool showNotes);
        List<Note> SeedNotes();
        User GetUserById(int id);
        User GetUserByFirstNameAndLastName(string firstName, string lastname);
        bool CreateUser(User user);
    }
}
