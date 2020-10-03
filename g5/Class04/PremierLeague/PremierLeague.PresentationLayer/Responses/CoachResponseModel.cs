using System;
using System.Collections.Generic;
using System.Text;

namespace PremierLeague.PresentationLayer.Responses
{
    public class CoachResponseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string TeamName { get; set; }
    }
}
