using GamesBoxd_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesBoxd_api.Data.Mappings;

public class DeveloperMapping : IEntityTypeConfiguration<Developer>
{
    public void Configure(EntityTypeBuilder<Developer> builder)
    {
        builder.ToTable("developer");

        builder.Property(d => d.Id)
            .HasColumnName("id")
            .HasColumnType("uuid")
            .IsRequired(true);

        builder.Property(d => d.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(80)
            .IsRequired();

        builder.HasIndex(g => g.Name)
            .IsUnique()
            .HasDatabaseName("idx_developer_name");
    }
}