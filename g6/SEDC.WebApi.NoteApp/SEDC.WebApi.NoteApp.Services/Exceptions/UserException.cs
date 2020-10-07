using System;

namespace SEDC.WebApi.NoteApp.Services.Exceptions
{
    public class UserException : Exception
    {
        public int? UserId { get; set; }
        public string Name { get; set; }

        public UserException(int? userId, string name)
            : base("There has beed an isssue with a user")
        {
            UserId = userId;
            Name = name;
        }

        public UserException(int? userId, string name, string message)
            : base(message)
        {
            UserId = userId;
            Name = name;
        }
    }
}
