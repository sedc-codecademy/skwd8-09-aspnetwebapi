using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PremierLeague.DataAccess.PremierLeague.DataAccess.DbAccess;
using PremierLeague.Repositories.Interfaces;
using PremierLeague.Repositories.Repositories;
using PremierLeague.Services.Mappings;
using PremierLeague.Services.Services;
using PremierLeague.Services.Services.Interfaces;

namespace PremierLeague.WebApi
{
    public class Startup
    {
        private static readonly Type[] AutoMapperProfiles = {
            typeof(MappingProfile)
        };

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AutoMapperProfiles);
            services.AddDbContext<PremierLeagueContext>(options => options.UseSqlServer("Server=.;Database=PremierLeague.Database;Trusted_Connection=True;"));
            services.AddTransient<IRepository<Team>, TeamRepository>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
