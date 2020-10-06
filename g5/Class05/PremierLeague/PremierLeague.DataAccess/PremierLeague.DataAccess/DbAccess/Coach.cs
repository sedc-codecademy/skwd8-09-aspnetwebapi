namespace PremierLeague.DataAccess.PremierLeague.DataAccess.DbAccess
{
    public partial class Coach
    {
        public Coach()
        {
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public int? Age { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
