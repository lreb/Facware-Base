using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreBase.Domain.Entities;
using NetCoreBase.Infrastructure.Data.Configurations.Common;

namespace NetCoreBase.Infrastructure.Data.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            BaseFluentValidationsConfigs.BaseFullEntityConfig(builder);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Price).IsRequired().HasDefaultValue(0);

            builder.HasData(
                new Item { Id = 1, Name = "Seed Data 1", Description = "Seed Data 1 Description", Price = 5.5m },
                new Item { Id = 2, Name = "Seed Data 2", Description = "Seed Data 2 Description", Price = 10.5m }
            );
        }

    }
}
