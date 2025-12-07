using Domain.Entities.IdentityModule;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Presistences.Identity
{
    public class StoreIdentityContext(DbContextOptions<StoreIdentityContext> options) : IdentityDbContext<User>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Address>().ToTable("Addresses");
        }

    }
}
