using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class RegistrationAppContext : DbContext
    {
        public RegistrationAppContext()
        {
        }

        public RegistrationAppContext(DbContextOptions<RegistrationAppContext> options) 
            : base(options)
        {
        }

        public DbSet<Registration> Registrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=RegistrationAppDb;Trusted_Connection=True;");
        }
    }
}
