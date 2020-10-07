using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace SEDC.WebApi.NoteApp.DataModel
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions opt)
            : base(opt)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // USER
            modelBuilder
                .Entity<User>()
                .ToTable("Users")
                .HasKey(p => p.Id);

            modelBuilder
                .Entity<User>()
                .Property(p => p.Username)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder
                .Entity<User>()
                .Property(p => p.Password)
                .HasMaxLength(100)
                .IsRequired();

            // NOTE
            modelBuilder
                .Entity<Note>()
                .ToTable("Notes")
                .HasKey(p => p.Id);

            modelBuilder
                .Entity<Note>()
                .Property(p => p.Text)
                .HasMaxLength(150);

            modelBuilder
                .Entity<Note>()
                .Property(p => p.Color)
                .HasMaxLength(20);

            modelBuilder
                .Entity<Note>()
                .HasOne(p => p.User)
                .WithMany(p => p.Notes)
                .HasForeignKey(p => p.UserId);

            Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public void Seed(ModelBuilder modelBuilder)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes("123456sedc"));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            modelBuilder.Entity<User>()
                .HasData(
                new User()
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    Username = "bob007",
                    Password = hashedPassword
                });
            modelBuilder.Entity<Note>()
                .HasData(
                new Note()
                {
                    Id = 1,
                    Text = "Buy Juice",
                    Color = "blue",
                    Tag = 4,
                    UserId = 1
                },
                new Note()
                {
                    Id = 2,
                    Text = "Learn ASP.NET Core WebApi",
                    Color = "orange",
                    Tag = 1,
                    UserId = 1
                }
                );
        }
    }
}
