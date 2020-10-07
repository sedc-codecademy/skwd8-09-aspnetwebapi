using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.WebApi.NoteApp.DataAccess;
using SEDC.WebApi.NoteApp.DataAccess.Adonet;
using SEDC.WebApi.NoteApp.DataAccess.Dapper;
using SEDC.WebApi.NoteApp.DataAccess.EntityFramework;
using SEDC.WebApi.NoteApp.DataModel;

namespace SEDC.WebApi.NoteApp.Services.Helpers
{
    public static class DiModule
    {
        public static IServiceCollection RegisterModule(
            IServiceCollection services,
            string connectionString)
        {
            // registering db context
            services.AddDbContext<NotesDbContext>(x =>
                x.UseSqlServer(connectionString));

            //register repositories
            //entity framework
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Note>, NoteRepository>();

            // adonet repos 
            //services.AddTransient<IRepository<User>>(
            //    x => new AdoUserRepository(connectionString));

            // Dapper reops
            //services.AddTransient<IRepository<User>>(
            //    x => new DapperUserRepository(connectionString));

            return services;
        }
    }
}
