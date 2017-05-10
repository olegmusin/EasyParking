using AutoMapper;
using AutoMapper.EquivalencyExpression;
using EasyParking.Domain;
using EasyParking.Domain.Abstract;
using EasyParking.Domain.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace EasyParking
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            _config = builder.Build();
            _env = env;
        }


        IConfigurationRoot _config;
        private IHostingEnvironment _env;


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);

            //services.AddTransient<IMapper, Mapper>();
            services.AddDbContext<ParkingDbContext>();
            services.AddTransient<IRepository, Repository<ParkingDbContext>>();
            services.AddTransient<ParkingIdentityInitializer>();
            services.AddTransient<ParkingDbInitializer>();

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ParkingDbContext>();
            services.AddMemoryCache();

            services.AddAuthorization(cfg =>
            {
                cfg.AddPolicy("SuperUsers", p => p.RequireClaim("SuperUser", "True"));
                cfg.AddPolicy("Users", p => p.RequireClaim("User", "True"));
            });
            //Automapper Initialization
            services.AddAutoMapper(cfg => cfg.AddCollectionMappers());

            // Add framework services.
            services.AddMvc();
            


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              ILoggerFactory loggerFactory,
                              ParkingIdentityInitializer identitySeeder,
                              ParkingDbInitializer seeder)
        {
            loggerFactory.AddConsole(_config.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseIdentity();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();

            seeder.Seed().Wait();
            identitySeeder.Seed().Wait();
        }
    }
}
