using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.WebApi.NoteApp.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // TODO: Add token here
        public string Token { get; set; }
    }
}
