using GamesBoxd_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesBoxd_api.Data.Mappings;

public class PublisherMapping : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.ToTable("publisher");

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasColumnType("uuid")
            .IsRequired(true);

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(80)
            .IsRequired(true);

        builder.HasIndex(p => p.Name)
            .IsUnique()
            .HasDatabaseName("idx_publisher_name");
    }
}