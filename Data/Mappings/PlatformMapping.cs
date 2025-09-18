using GamesBoxd_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesBoxd_api.Data.Mappings;

public class PlatformMapping : IEntityTypeConfiguration<Platform>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Platform> builder)
    {
        builder.ToTable("platform");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasColumnType("uuid")
            .IsRequired(true);

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(25)
            .IsRequired(true);

        builder.HasIndex(p => p.Name)
            .IsUnique()
            .HasDatabaseName("idx_platform_name");
    }
}