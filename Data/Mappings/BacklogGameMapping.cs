using GamesBoxd_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesBoxd_api.Data.Mappings;

public class BacklogGameMapping : IEntityTypeConfiguration<BacklogGame>
{
    public void Configure(EntityTypeBuilder<BacklogGame> builder)
    {
        builder.ToTable("backlog_game");

        builder.HasKey(bg => new { bg.BacklogId, bg.GameId });

        builder.HasOne(bg => bg.Backlog)
            .WithMany(b => b.BacklogGames)
            .HasForeignKey(bg => bg.BacklogId)
            .HasConstraintName("fk_backloggame_backlog_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(bg => bg.Game)
            .WithMany(b => b.BacklogGames)
            .HasForeignKey(bg => bg.GameId)
            .HasConstraintName("fk_backloggame_game_id")
            .OnDelete(DeleteBehavior.Cascade);

    }
}