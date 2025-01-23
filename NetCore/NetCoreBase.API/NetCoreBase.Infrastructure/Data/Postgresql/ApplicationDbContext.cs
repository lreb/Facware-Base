using Microsoft.EntityFrameworkCore;
using NetCoreBase.Infrastructure.Data.Seeds;
using NetCoreBase.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBase.Infrastructure.Data.Postgresql
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; }
        //public virtual DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Seed();
            modelBuilder.ApplyConfiguration(new SeedConfiguration());
        }
    }
}
