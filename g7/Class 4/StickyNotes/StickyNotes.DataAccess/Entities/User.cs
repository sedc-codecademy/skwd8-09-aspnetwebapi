using System;
using System.Collections.Generic;

namespace StickyNotes.DataAccess.Entities
{
    public partial class User
    {
        public User()
        {
            Notes = new HashSet<Note>();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
