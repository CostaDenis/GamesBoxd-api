using GamesBoxd_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesBoxd_api.Data.Mappings;

public class GenreMapping : IEntityTypeConfiguration<Genre>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable("genre");

        builder.Property(g => g.Id)
            .HasColumnName("id")
            .HasColumnType("uuid")
            .IsRequired(true);

        builder.Property(g => g.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(30)
            .IsRequired(true);
    }
}