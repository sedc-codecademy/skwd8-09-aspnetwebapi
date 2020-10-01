namespace PremierLeague.Models
{
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public Player()
        {
            
        }

        public Player(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
