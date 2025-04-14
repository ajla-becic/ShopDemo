using AbySalto.Mid.Domain.Interfaces;
using AbySalto.Mid.Infrastructure.DatabaseContext;
using AbySalto.Mid.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.EntityFrameworkCore;
using AbySalto.Mid.Application.Interfaces;


namespace AbySalto.Mid
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AbySalto", Version = "v1" });
            });

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShopDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            // Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
