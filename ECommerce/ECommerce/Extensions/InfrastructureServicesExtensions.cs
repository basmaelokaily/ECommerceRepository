using Domain.Contracts;
using Domain.Entities.IdentityModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Presistences.Data;
using Presistences.Identity;
using Presistences.Repositories;
using StackExchange.Redis;

namespace ECommerce.Extensions
{
    public static class InfrastructureServicesExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<IUniteOfWork, UniteOfWork>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddDbContext<StoreDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddDbContext<StoreIdentityContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("IdentitySQLConnection"));
            });
            services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")!));
            services.ConfigureIdentityServices();
            return services;
        }

        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<StoreIdentityContext>();
            return services;
        }

       
    }
}
