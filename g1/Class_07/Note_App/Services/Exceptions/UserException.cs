using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Exceptions
{
    public class UserException : Exception
    {
        public int? UserId { get; set; }
        public UserException() : base("There has been an issue with the user")
        {

        }
        public UserException(int? userId,string message) : base(message)
        {
            UserId = userId;
        }
    }
}
