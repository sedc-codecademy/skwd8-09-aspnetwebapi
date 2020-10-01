using System;

namespace PremierLeague.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Town { get; set; }

        public Team()
        {
        }

        public Team(string name, string town)
        {
            var rnd = new Random();
            Id = rnd.Next(1, int.MaxValue);
            Name = name;
            Town = town;
        }
    }
}
