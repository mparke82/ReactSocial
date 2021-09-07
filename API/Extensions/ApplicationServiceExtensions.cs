using Application.Activities;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API.Extensions
{
    // Using this to return a collection of services to keep the startup class clean
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, 
            IConfiguration config)
        {
            services.AddSwaggerGen(c => // Added by template from microsoft
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
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
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}