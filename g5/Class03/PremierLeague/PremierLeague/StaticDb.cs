using System.Collections.Generic;
using PremierLeague.Models;

namespace PremierLeague
{
    public static class StaticDb
    {
        public static List<Team> Teams = new List<Team>()
        {
            new Team("Liverpool", "Liverpool"),
            new Team("Chelsea", "London")
        };

        public static List<Player> Players = new List<Player>()
        {
            new Player("Mo", "Salah"),
            new Player("Sadio", "Mane")
        };
    }
}
