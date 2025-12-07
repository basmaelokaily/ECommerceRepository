using Domain.Contracts;
using ECommerce.Middlewares;

namespace ECommerce.Extensions
{
    public static class WebApplicationExtensions
    {
        public static async Task<WebApplication> SeedDbAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            await dbInitializer.InitializeAsync();
            await dbInitializer.InitializeIdentityAsync();
            return app;
        }

        public static WebApplication UseCustomExceptionMiddleWares(this WebApplication app)
        {
            app.UseMiddleware<GlobalErrorHandlingMiddleware>();
            return app;
        }

        public static WebApplication UseSwaggerMiddleware(this WebApplication app) {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}
