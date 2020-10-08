using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.NoteApp.DataAccess;
using SEDC.NoteApp.DataAccess.ADONET;
using SEDC.NoteApp.DataAccess.DapperRepositories;
using SEDC.NoteApp.DataModels;

namespace SEDC.NoteApp.Services.Helpers
{
    public static class DIModule
    {
        public static IServiceCollection RegisterModule(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<NoteDbContext>(x => 
                x.UseSqlServer(connectionString));


            //ADO.NET Repositories registration
            //services.AddTransient<IRepository<UserDTO>>(x => new UserRepositoryADO(connectionString));

            //Dapper Repositories Registration
            services.AddTransient<IRepository<UserDTO>>(x => new UserRepositoryDapper(connectionString));

            return services;
        }
    }
}
