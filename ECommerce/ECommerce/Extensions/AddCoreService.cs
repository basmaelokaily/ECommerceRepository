using Services;
using Services.Abstraction.Contracts;
using Services.Implementations;

namespace ECommerce.Extensions
{
    public static class AddCoreService
    {
        public static void AddCoreServices(this IServiceCollection services) {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddAutoMapper(a => { }, typeof(AssemblyReference).Assembly);

        }
    }
}
