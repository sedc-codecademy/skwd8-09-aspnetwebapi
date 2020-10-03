using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.NoteApp.DataModels;

namespace SEDC.NoteApp.Services.Helpers
{
    public static class DIModule
    {
        public static IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddDbContext<NoteDbContext>(x => 
                x.UseSqlServer("Server=.;Database=NotesDemoDb;Trusted_Connection=True"));

            return services;
        }
    }
}
