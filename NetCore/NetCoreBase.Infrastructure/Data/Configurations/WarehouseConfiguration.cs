using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreBase.Domain.Entities;
using NetCoreBase.Infrastructure.Data.Configurations.Common;

namespace NetCoreBase.Infrastructure.Data.Configurations
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            BaseFluentValidationsConfigs.BaseFullEntityConfig(builder);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Location).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Capacity).IsRequired().HasDefaultValue(0);

            builder.HasData(
                new Warehouse { Id = 1, Name = "Warehouse 1", Location = "México", Capacity = 10000 },
                new Warehouse { Id = 2, Name = "Warehouse 2", Location = "China", Capacity = 100000 }
            );
        }
    }
}
