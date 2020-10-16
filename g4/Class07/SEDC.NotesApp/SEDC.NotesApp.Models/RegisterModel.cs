using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Models
{
    public class RegisterModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
