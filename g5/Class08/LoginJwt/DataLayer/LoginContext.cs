using System;
using System.Collections.Generic;
using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class LoginContext : DbContext
    {
        public LoginContext()
        {
        }

        public LoginContext(DbContextOptions<LoginContext> options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=LoginDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserRole>()
            //    .HasOne(x => x.User)
            //    .WithMany(x => x.UserRoles)
            //    .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Role>().HasData(new List<Role>
            {
                new Role() {Id = 1, Name = "Admin", Description = "This is admin role"},
                new Role() {Id = 2, Name = "User", Description = "This is user role"}
            });
        }
    }
}
