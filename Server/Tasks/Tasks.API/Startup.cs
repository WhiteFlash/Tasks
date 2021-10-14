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
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;

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
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy(Environments.Development, policy => policy
                    .WithOrigins("https://localhost:3000",
                                 "http://localhost:3000",
                                 "http://localhost:5000",
                                 "http://localhost:5001",
                                 "https://localhost:44311")
                    .AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });
            
            services.AddTransient<DataContext>();

            services.AddDbContext<DataContext>(option => option.UseSqlite(Configuration.GetConnectionString("TasksDb")));
           
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tasks API", Description = "All APIs CRUD for project." }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API"));
            }

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); 
            });
        }
    }
}
