using StickyNotes.WebAPI.Database.Interfaces;
using StickyNotes.WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace StickyNotes.WebAPI.Database
{
    public class MockupDataContext : IDatabase
    {
        public MockupDataContext()
        {
            //_notes = SeedNotes();
            //_users = SeedUsers();
        }
        private static List<User> _users = new List<User>()
            {
                new User()
                {
                    FirstName = "Jon",
                    LastName = "Whayne",
                    UserName = "bat",
                    Location = new Location()
                    {
                        Address = "Ghotam city",
                        City = "NY",
                        Coordinates = "2.5.21",
                        Country = "USA"
                    },
                    Password = "iambatman",
                    Notes = new List<Note>()
                },
                new User()
                {
                    FirstName = "Clark",
                    LastName = "Kent",
                    UserName = "super",
                    Location = new Location()
                    {
                        Address = "On a farm",
                        City = "Village",
                        Coordinates = "2.5.21",
                        Country = "USA"
                    },
                    Password = "iamjustajournalist",
                    Notes = new List<Note>()
                }
            };

        private static List<Note> _notes = new List<Note>()
            {
                new Note()
                {
                    Title = "Save Ghotam",
                    Text = "Here to help",
                    Color = Color.Green,
                },
                new Note()
                {
                     Title = "Save the planet",
                    Text = "Here to help everybody",
                    Color = Color.Red,
                },
                new Note()
                {
                     Title = "Save Ghotam and kill the Joker",
                    Text = "Here to kill the Joker",
                    Color = Color.Green,
                },
                new Note()
                {
                     Title = "Save Jane",
                    Text = "Here to save Jane",
                    Color = Color.Red,
                }
            };

        public List<User> SeedUsers(bool showNotes = true)
        {
            switch (showNotes)
            {
                case true:
                    return _users;
                default:
                    _users.ForEach(u => u.Notes = new List<Note>());
                    break;
            }
            return _users;
        }

        public List<Note> SeedNotes()
        {
            return _notes;
        }

        public User GetUserById(int id)
        {
            var user = _users.SingleOrDefault(u => u.ID == id);
            if (user == null)
            {
                throw new ApplicationException("User not found");
            }
            return user;
        }
        public User GetUserByFirstNameAndLastName(string firstname, string lastName)
        {
            var user = _users.SingleOrDefault(u => u.FirstName == firstname && u.LastName == lastName);
            if (user == null)
            {
                throw new ApplicationException("User not found");
            }
            return user;
        }

        public bool CreateUser(User user)
        {
            var foundUser = _users.SingleOrDefault(x => x.UserName == user.UserName);
            if (foundUser == null)
            {
                foundUser = new User();
                foundUser.FirstName = user.FirstName;
                foundUser.LastName = user.LastName;
                foundUser.UserName = user.UserName;
                foundUser.Password = user.Password;
                foundUser.Location = user.Location;
                foundUser.Notes = new List<Note>();
                _users.Add(foundUser);
                return true;
            }
            return false;
        }
    }
}
