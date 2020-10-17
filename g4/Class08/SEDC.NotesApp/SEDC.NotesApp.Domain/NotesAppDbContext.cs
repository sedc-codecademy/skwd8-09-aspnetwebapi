using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SEDC.NotesApp.Domain.Models;

namespace SEDC.NotesApp.Domain
{
    public class NotesAppDbContext:DbContext
    {
        public NotesAppDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Note>()
                .Property(x => x.Text)
                .HasMaxLength(100)
                .IsRequired(); // not null
            modelBuilder.Entity<Note>()
                .Property(x => x.Color)
                .HasMaxLength(30);
            //relation
            modelBuilder.Entity<Note>()
                .HasOne(x => x.User)
                .WithMany(x => x.Notes)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<User>()
                .Property(x => x.Username)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.FirstName)
                .HasMaxLength(50);
            modelBuilder.Entity<User>()
                .Property(x => x.LastName)
                .HasMaxLength(50);
            modelBuilder.Entity<User>()
                .Ignore(x => x.Age); //don't make a column for Age prop
            modelBuilder.Entity<User>()
                .Property(x => x.Address)
                .HasMaxLength(150);

            //SEED
        }
    }
}
