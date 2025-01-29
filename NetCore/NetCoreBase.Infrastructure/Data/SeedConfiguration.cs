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
            ItemSeed.Seed(builder);
        }   
    }
}
