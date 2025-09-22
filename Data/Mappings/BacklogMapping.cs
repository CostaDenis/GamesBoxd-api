using GamesBoxd_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesBoxd_api.Data.Mappings;

public class BacklogMapping : IEntityTypeConfiguration<Backlog>
{
    public void Configure(EntityTypeBuilder<Backlog> builder)
    {
        builder.ToTable("backlog");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasColumnName("id")
            .HasColumnType("uuid")
            .IsRequired(true);

        builder.HasOne(b => b.User)
            .WithOne(u => u.Backlog)
            .HasForeignKey<Backlog>(b => b.UserId)
            .HasConstraintName("fk_backlog_user_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(b => b.BacklogGames)
            .WithOne(bg => bg.Backlog)
            .HasForeignKey(bg => bg.BacklogId)
            .HasConstraintName("fk_backloggame_backlog_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}