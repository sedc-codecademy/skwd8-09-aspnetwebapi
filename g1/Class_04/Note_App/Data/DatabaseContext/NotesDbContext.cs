using System;
using Domain_Models.Enums;
using Domain_Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.DatabaseContext
{
    public partial class NotesDbContext : DbContext
    {
        public NotesDbContext()
        {
        }

        public NotesDbContext(DbContextOptions<NotesDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			Seed(modelBuilder);
			base.OnModelCreating(modelBuilder);
		}


		public void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.HasData(
					new User()
					{
						Id = 1,
						FirstName = "Bob",
		
						LastName = "Bobsky",
		
						UserName = "bob007",
						Password = "12345"
					},
					new User()
					{
						Id = 2,
						FirstName = "Rob",
		
						LastName = "Robsky",
		
						UserName = "R.R",
						Password = "67890"
					},
					new User()
					{
						Id = 3,
						FirstName = "James",
		
						LastName = "Bond",
		
						UserName = "Bond",
						Password = "BondJamesBond"
					}
				);
			modelBuilder.Entity<Note>()
				.HasData(
					new Note()
					{
						Id = 1,
						Text = "Buy Juice",
						Color = "blue",
						Tag = TagType.Health,
						UserId = 1
					},
					new Note()
					{
						Id = 2,
						Text = "Learn ASP.NET Core WebApi",
						Color = "red",
						Tag = TagType.School,
						UserId = 1
					},
					new Note()
					{
						Id = 3,
						Text = "Ask for raise",
						Color = "green",
						Tag = TagType.Work,
						UserId = 2
					},
					new Note()
					{
						Id = 4,
						Text = "Do the dishes",
						Color = "white",
						Tag = TagType.Home,
						UserId = 1
					},
					new Note()
					{
						Id = 5,
						Text = "Do the laundry",
						Color = "black",
						Tag = TagType.Home,
						UserId = 2
					},
					new Note()
					{
						Id = 6,
						Text = "Call Rob",
						Color = "orange",
						Tag = TagType.Home,
						UserId = 1
					},
					new Note()
					{
						Id = 7,
						Text = "Save the world!",
						Color = "yellow",
						Tag = TagType.Health,
						UserId = 3
					}
				);
		}
	}
}
