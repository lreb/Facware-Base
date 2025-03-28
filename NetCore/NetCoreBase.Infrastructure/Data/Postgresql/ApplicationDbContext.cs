using Microsoft.EntityFrameworkCore;
using NetCoreBase.Domain.Entities;

namespace NetCoreBase.Infrastructure.Data.Postgresql
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddEntityConfigurations();
        }
    }
}
