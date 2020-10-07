using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DummyData
{
    public class DummyDataDbContext : DbContext
    {
        public DummyDataDbContext(DbContextOptions<DummyDataDbContext> options) : base(options) { }

        DbSet<Customer> Customers { get; set; }

        DbSet<Order> Orders { get; set; }
    }
}
