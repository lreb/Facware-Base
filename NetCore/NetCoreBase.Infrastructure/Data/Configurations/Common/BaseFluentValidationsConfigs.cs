using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreBase.Domain.Common;

namespace NetCoreBase.Infrastructure.Data.Configurations.Common
{
    public static class BaseFluentValidationsConfigs
    {
        public static void BaseFullEntityConfig<T>(EntityTypeBuilder<T> builder) where T : BaseFullEntity
        {
            // Configure the primary key as a generated database ID key
            BaseAuditableEntityConfig(builder);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
        }

        public static void BaseAuditableEntityConfig<T>(EntityTypeBuilder<T> builder) where T : BaseAuditableEntity
        {
            // Configure the primary key as a generated database ID key
            BaseEntityConfig(builder);
            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamptz")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(x => x.CreatedBy).IsRequired().HasDefaultValue("system");
            builder.Property(x => x.UpdatedAt)
                .HasColumnType("timestamptz")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }

        public static void BaseEntityConfig<T>(EntityTypeBuilder<T> builder) where T : BaseEntity
        {
            // Configure the primary key as a generated database ID key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}