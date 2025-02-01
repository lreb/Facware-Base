using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NetCoreBase.Infrastructure.Data.Seeds
{
    public static class GenericSeed
    {
        public static EntityTypeBuilder<T> Seed<T>(this EntityTypeBuilder<T> builder, params T[] seedData) where T : class
        {
            builder.HasData(seedData);
            return builder;
        }

    }
}
