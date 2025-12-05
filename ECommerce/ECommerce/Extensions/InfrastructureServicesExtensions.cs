using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Presistences.Data;
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
            services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")!));
            
            return services;
        }
    }
}
