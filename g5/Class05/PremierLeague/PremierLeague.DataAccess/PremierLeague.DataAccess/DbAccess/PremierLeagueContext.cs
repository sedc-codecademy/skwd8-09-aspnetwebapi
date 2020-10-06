using Microsoft.EntityFrameworkCore;

namespace PremierLeague.DataAccess.PremierLeague.DataAccess.DbAccess
{
    public partial class PremierLeagueContext : DbContext
    {
        public PremierLeagueContext()
        {
        }

        public PremierLeagueContext(DbContextOptions<PremierLeagueContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coach> Coach { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Team> Team { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=PremierLeague.Database;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coach>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.HasOne(c => c.Team)
                    .WithOne(t => t.CoachNavigation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasForeignKey<Coach>(x => x.TeamId)
                    .HasConstraintName("FK_Coach_TeamID");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.HasOne(p => p.Team)
                    .WithMany(t => t.Player)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Player_TeamID");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CoachId).HasColumnName("CoachID");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(t => t.CoachNavigation)
                    .WithOne(c => c.Team)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasForeignKey<Team>(x => x.CoachId)
                    .HasConstraintName("FK_Team_CoachID");
            });
        }
    }
}
