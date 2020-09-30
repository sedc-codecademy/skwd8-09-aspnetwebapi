using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SEDC.WebApi.NoteApp.DataModels.DbModels
{
    public partial class NotesDbContext : DbContext
    {

        // scafold command
        // Scaffold-DbContext "Server=(LocalDb)\MSSQLLocalDB;Database=NotesExample;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DbModels -Context NotesDbContext
        public NotesDbContext()
        {
        }

        public NotesDbContext(DbContextOptions<NotesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=NotesExample;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notes>(entity =>
            {
                entity.Property(e => e.Color).HasMaxLength(30);

                entity.Property(e => e.Text).HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notes__UserId__25869641");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(30);
            });
        }
    }
}
