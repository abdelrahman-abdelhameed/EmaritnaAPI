using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Emaritna.DAL.Entity.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emaritna.DAL.Context
{
    public class ClinicContext : IdentityDbContext<ApplicationUser>
    {

        public ClinicContext(DbContextOptions<ClinicContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
