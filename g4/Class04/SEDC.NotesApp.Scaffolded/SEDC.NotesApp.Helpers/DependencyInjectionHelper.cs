using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.NotesApp.Domain.Models;

namespace SEDC.NotesApp.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services)
        {
            services.AddDbContext<NotesScaffoldedDbContext>(x =>
                x.UseSqlServer("Server=.;Database=NotesScaffoldedDb;Trusted_Connection=True"));
        }
    }
}
