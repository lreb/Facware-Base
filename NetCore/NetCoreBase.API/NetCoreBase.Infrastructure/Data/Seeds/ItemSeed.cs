using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreBase.Domain.Entities;

namespace NetCoreBase.Infrastructure.Data.Seeds
{
    public class ItemSeed
    {
        public static void Seed(EntityTypeBuilder<Item> builder)
        {
            builder.HasData(
                            new Item { Id = 1, Name = "Seed Data 1" },
                            new Item { Id = 2, Name = "Seed Data 2" }
                        );
        }
    }
}
