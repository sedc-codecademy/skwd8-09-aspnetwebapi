namespace StickyNotes.API.Models
{
    public class CreateUserRequest
    {
        public string Firstname { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
