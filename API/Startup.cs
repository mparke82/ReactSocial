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
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using MediatR;
using Application.Activities;

namespace API
{
    public class Startup
    {
        // Specifying that we want our configuration to be injected into our startup class
        // Our configuration when we inject it gives us access to anything in our configuration files
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(); // API projects have API controllers
            services.AddSwaggerGen(c => // Added by template from microsoft
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(_config.GetConnectionString("DefaultConnection"));
            });
            // opt = options
            // This cors is required when trying to access a resource from a different domain
            // Our client app is on localhost port 3000, and api server is on port 5000
            // Cors becomes irrelevant after publishing
            services.AddCors(opt => {
                opt.AddPolicy("CorsPolicy", policy => {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
                });
            });
            services.AddMediatR(typeof(List.Handler).Assembly); // Tell Mediator where our handlers are located and which assembly
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // Ordering is important in this method
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Check to see that we're in development mode
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            // app.UseHttpsRedirection();

            // When HTTP requests come in from our client, inside this class the router routes to our endpoints inside our controllers
            app.UseRouting(); // route requests to appropriate API controller

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // our controllers have API endpoints
            });
        }
    }
}
