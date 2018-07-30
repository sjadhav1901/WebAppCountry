using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Db.Core.Utilites;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Country.ApiIntegrations;
using WebApp.Country.Helpers;
using WebApp.Country.Repositories;

namespace WebApp.Country
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            this.Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDataSettings, DataSettings>();
            services.AddTransient<IPasswordHasher<string>, PasswordHasher<string>>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRecentActivityRepository, RecentActivityRepository>();
            services.AddTransient<IActivityHelper, ActivityHelper>();
            services.AddTransient<IRoleFeatureMappingRepository, RoleFeatureMappingRepository>();
            services.AddTransient<IFeatureRepository, FeatureRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IFavouriteRepository, FavouriteRepository>();
            services.AddTransient<IApiCountryAll, ApiCountryAll>();
            services.AddTransient<IFavouriteRepository, FavouriteRepository>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Authentication}/{action=SignIn}/{id?}");
            });

            Mapper.Initialize(cfg => cfg.CreateMap<Contracts.DataModels.User, Contracts.Models.User>());
        }
    }
}
