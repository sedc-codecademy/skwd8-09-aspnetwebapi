using System.Collections.Generic;

namespace PremierLeague.PresentationLayer.Responses
{
    public class TeamResponseModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int? TitlesWon { get; set; }
        public string CoachName { get; set; }
        public List<string> PlayerNames { get; set; }
    }
}
