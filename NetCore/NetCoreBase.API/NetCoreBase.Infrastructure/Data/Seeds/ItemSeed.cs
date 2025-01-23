using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreBase.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
