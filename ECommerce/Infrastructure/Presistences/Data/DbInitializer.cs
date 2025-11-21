using Domain.Contracts;
using Domain.Entities.ProductModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presistences.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly StoreDbContext _dbContext;
        
        public DbInitializer(StoreDbContext dbContext) { 
            _dbContext = dbContext;
        }
        public async Task InitializeAsync()
        {
            //create database if it doesn't exist and applying any pending migration
            try {
                if (_dbContext.Database.GetPendingMigrations().Any())
                    await _dbContext.Database.MigrateAsync();
                //apply the data seeding
                if (!_dbContext.productTypes.Any())
                {
                    //read types from file as a string
                    var typeData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistences\Data\DataSeeding\types.json");
                    //transform from json into c# object
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);
                    //add types Into Db and save changes
                    if (types is not null && types.Any())
                    {
                        await _dbContext.productTypes.AddRangeAsync(types);
                        await _dbContext.SaveChangesAsync();

                    }
                }

                if (!_dbContext.productBrands.Any())
                {
                    //read types from file as a string
                    var brandData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistences\Data\DataSeeding\brands.json");
                    //transform from json into c# object
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                    //add types Into Db and save changes
                    if (brands is not null && brands.Any())
                    {
                        await _dbContext.productBrands.AddRangeAsync(brands);
                        await _dbContext.SaveChangesAsync();

                    }
                }

                if (!_dbContext.Products.Any())
                {
                    //read types from file as a string
                    var productData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistences\Data\DataSeeding\products.json");
                    //transform from json into c# object
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);
                    //add types Into Db and save changes
                    if (products is not null && products.Any())
                    {
                        await _dbContext.Products.AddRangeAsync(products);
                        await _dbContext.SaveChangesAsync();

                    }
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
    }
}
