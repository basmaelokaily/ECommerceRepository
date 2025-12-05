
using Domain.Contracts;
using ECommerce.Extensions;
using ECommerce.Factories;
using ECommerce.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presistences.Data;
using Presistences.Repositories;
using Services;
using Services.Abstraction.Contracts;
using Services.Implementations;

namespace ECommerce
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddWebApiServices();

            //infrastructure
            builder.Services.AddInfrastructureServices(builder.Configuration);

            //core service
            builder.Services.AddCoreServices();

            var app = builder.Build();

            #region configure kestrel middlewares
            app.UseCustomExceptionMiddleWares();
            await app.SeedDbAsync();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerMiddleware();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
            #endregion

        }
    }
}
