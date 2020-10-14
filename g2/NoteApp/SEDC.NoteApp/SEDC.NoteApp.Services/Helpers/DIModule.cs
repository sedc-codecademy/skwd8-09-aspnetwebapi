using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.NoteApp.DataAccess;
using SEDC.NoteApp.DataAccess.ADONET;
using SEDC.NoteApp.DataAccess.DapperRepositories;
using SEDC.NoteApp.DataAccess.EntityFramework;
using SEDC.NoteApp.DataModels;

namespace SEDC.NoteApp.Services.Helpers
{
    public static class DIModule
    {
        public static IServiceCollection RegisterModule(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<NoteDbContext>(x => 
                x.UseSqlServer(connectionString));

            //Entity framework repositories registration
            services.AddTransient<IRepository<UserDTO>, UserRepository>();
            services.AddTransient<IRepository<NoteDTO>, NoteRepository>();

            //ADO.NET Repositories registration
            //services.AddTransient<IRepository<UserDTO>>(x => new UserRepositoryADO(connectionString));
            //services.AddTransient<IRepository<NoteDTO>>(x => new NoteRepositoryADO(connectionString));

            //Dapper Repositories Registration
            //services.AddTransient<IRepository<UserDTO>>(x => new UserRepositoryDapper(connectionString));
            //services.AddTransient<IRepository<NoteDTO>>(x => new NoteRepositoryDapper(connectionString));


            return services;
        }
    }
}
