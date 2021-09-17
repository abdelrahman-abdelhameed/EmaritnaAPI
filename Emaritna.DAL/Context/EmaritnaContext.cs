using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Emaritna.DAL.Entity.Users;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;

namespace Emaritna.DAL.Context
{
    public class EmaritnaContext : IdentityDbContext<ApplicationUser>
    {

        public EmaritnaContext(DbContextOptions<EmaritnaContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            
            base.OnModelCreating(modelBuilder);
        }

    }

      public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EmaritnaContext>
    {
        public EmaritnaContext CreateDbContext(string[] args)
        {

            var builder = new DbContextOptionsBuilder<EmaritnaContext>();
             var connectionString = "Data Source=localhost;Initial Catalog=Emaritna;User Id=sa;Password=!2456Avd;";
            builder.UseSqlServer(connectionString);
            return new EmaritnaContext(builder.Options);
        }
    }
}
