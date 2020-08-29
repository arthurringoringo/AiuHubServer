using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AiuHubServer.Infrastructure.DataContext;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using AiuHubServer.Infrastructure.DbExtension;
using System.Reflection;
using AiuHubServer.Services.SarraService;
using AiuHubServer.Services;
using AiuHubServer.Repository;

namespace AiuHubServer
{
    public class Startup
    {
        private const string AllowOrigins = "*";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ServerDBContext>(
                   e =>
                   {
                       e.EnableSensitiveDataLogging();
                       e.UseNpgsql(Configuration["POSTGRES_CONNECTIONSTRING"],
                       sqlOptions =>
                       {
                           sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                           sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
                       });
                   });


            services.AddScoped<ISarraAPIService, SarraAPIService>();
            services.AddScoped<INewsAndAnnouncementService, NewsAndAnnouncementService>();
            services.AddScoped<INewsAndAnnouncementRepository, NewsAndAnnouncementRepository>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UpdateDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(AllowOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
