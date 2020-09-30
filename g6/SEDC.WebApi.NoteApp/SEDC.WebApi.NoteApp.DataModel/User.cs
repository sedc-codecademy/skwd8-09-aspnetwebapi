using System.Collections.Generic;

namespace SEDC.WebApi.NoteApp.DataModel
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<Note> Notes { get; set; }
    }
}