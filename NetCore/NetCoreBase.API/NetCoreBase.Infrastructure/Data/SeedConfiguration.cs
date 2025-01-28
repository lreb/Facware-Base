using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreBase.Domain.Entities;
using NetCoreBase.Infrastructure.Data.Seeds;

namespace NetCoreBase.Infrastructure.Data
{
    internal class SeedConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            //builder.HasKey(e => e.Id);
            //builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            
            ItemSeed.Seed(builder);
        }   
    }
}
