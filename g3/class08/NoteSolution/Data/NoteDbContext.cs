using Microsoft.EntityFrameworkCore;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class NoteDbContext : DbContext
    {
        // this options come from Startup.cs whenever we want an object from NoteDbContext in a contructor
        public NoteDbContext(DbContextOptions<NoteDbContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
