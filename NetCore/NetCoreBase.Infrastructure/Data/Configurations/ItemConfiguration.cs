using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreBase.Domain.Entities;

namespace NetCoreBase.Infrastructure.Data.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            builder.HasData(
                new Item { Id = 1, Name = "Seed Data 1" },
                new Item { Id = 2, Name = "Seed Data 2" }
            );
        }
    }
}
