using System;
using System.Collections.Generic;

namespace PremierLeague.DataAccess.PremierLeague.DataAccess.DbAccess
{
    public partial class Team
    {
        public Team()
        {
            Player = new HashSet<Player>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int? TitlesWon { get; set; }
        public int CoachId { get; set; }

        public Coach CoachNavigation { get; set; }
        public ICollection<Player> Player { get; set; }
    }
}
