using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SEDC.NotesApp.Domain.Models;

namespace SEDC.NotesApp.Domain
{
    public class NotesAppDbContext:DbContext
    {
        public NotesAppDbContext(DbContextOptions options):base (options)
        {
            
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
