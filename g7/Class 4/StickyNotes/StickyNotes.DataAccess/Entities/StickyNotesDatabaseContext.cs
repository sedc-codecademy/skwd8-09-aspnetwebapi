using System;
using Microsoft.EntityFrameworkCore;

namespace StickyNotes.DataAccess.Entities
{
    public partial class StickyNotesDatabaseContext : DbContext
    {
        public StickyNotesDatabaseContext()
        {
        }

        public StickyNotesDatabaseContext(DbContextOptions<StickyNotesDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=StickyNotes.Database;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("smalldatetime").IsRequired();

                entity.Property(e => e.DeletedOn).HasColumnType("smalldatetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserFk).HasColumnName("User_FK");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.UserFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Note_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("smalldatetime").IsRequired();

                entity.Property(e => e.DeletedOn).HasColumnType("smalldatetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
