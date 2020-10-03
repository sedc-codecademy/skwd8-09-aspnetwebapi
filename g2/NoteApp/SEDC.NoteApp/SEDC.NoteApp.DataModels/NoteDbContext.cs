using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace SEDC.NoteApp.DataModels
{
    public class NoteDbContext : DbContext
    {
        public NoteDbContext(DbContextOptions options) 
            :base(options) { }

        public DbSet<UserDTO> Users { get; set; }
        public DbSet<NoteDTO> Notes { get; set; }


        public void Seed(ModelBuilder modelBuilder)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes("bob123456!"));
            var hasshedPassword = Encoding.ASCII.GetString(md5data);

            modelBuilder.Entity<UserDTO>()
                .HasData(
                    new UserDTO
                    {
                        Id = 1,
                        FirstName = "Bob",
                        LastName = "Bobsky",
                        Username = "bob007",
                        Password = hasshedPassword
                    });

            modelBuilder.Entity<NoteDTO>()
                .HasData(
                    new NoteDTO
                    {
                        Id = 1,
                        Text = "Buy some bread",
                        Color = "orange",
                        Tag = 4,
                        UserId = 1
                    },
                    new NoteDTO
                    {
                        Id = 2,
                        Text = "Learn ASP .NET core WebApi",
                        Color = "red",
                        Tag = 1,
                        UserId = 1
                    }
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NoteDTO>()
                .HasOne(x => x.User)
                .WithMany(x => x.Notes)
                .HasForeignKey(x => x.UserId);

            Seed(modelBuilder);
        }
    }
}
