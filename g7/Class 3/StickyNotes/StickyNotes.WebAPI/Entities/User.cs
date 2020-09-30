using System.Collections.Generic;

namespace StickyNotes.WebAPI.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public Location Location { get; set; }
        public string Password { get; set; }
        public IEnumerable<Note> Notes { get; set; }
    }
}
