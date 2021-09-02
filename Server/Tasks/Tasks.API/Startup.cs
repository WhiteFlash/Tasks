using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasks.DAL.Data;
using Newtonsoft.Json;
using System.Diagnostics;
using Tasks.DAL.Data.Interfaces;

namespace Tasks.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(Environments.Development, policy => policy
                    .WithOrigins("https://localhost:3000", "http://localhost:3000", "https://localhost:44311")
                    .AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
                options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                options.SerializerSettings.DateParseHandling = DateParseHandling.DateTime;
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            });

            //services.AddScoped<IDataContext, DataContext>();
            //services.AddScoped<Core.Services.ITasks, Core.Model.Tasks>();
            //services.AddScoped<Core.Services.IStatus, Core.Model.Status>();
            
            services.AddDbContext<DataContext>(option => option.UseSqlite(Configuration.GetConnectionString("TasksDB")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            switch (env)
            {
                case var value when Debugger.IsAttached:
                    app.UseCors(policy => policy
                        .WithOrigins("https://localhost:3000",
                                     "http://localhost:3000",
                                     "https://localhost:44311",
                                     "https://localhost:5001",
                                     "http://localhost:5000"
                        )
                        .AllowAnyMethod().AllowAnyHeader().AllowCredentials());
                    break;
                case var value when value.IsEnvironment(Environments.Development):
                    app.UseCors(Environments.Development);
                    break;
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.UseMiddleware<DataContext>();
            //app.UseMiddleware<Tasks>();
            //app.UseMiddleware<Status>();
        }
    }
}
