using Microsoft.EntityFrameworkCore;
using NetCoreBase.Infrastructure.Data.Configurations;

namespace NetCoreBase.Infrastructure.Data
{
    internal static class EntityConfigurations
    {
        internal static ModelBuilder AddEntityConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemConfiguration());

            return modelBuilder;
        }
    }
}
