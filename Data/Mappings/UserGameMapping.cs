using GamesBoxd_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesBoxd_api.Data.Mappings;

public class UserGameMapping : IEntityTypeConfiguration<UserGame>
{
    public void Configure(EntityTypeBuilder<UserGame> builder)
    {
        builder.ToTable("user_games");

        builder.HasKey(ug => new { ug.UserId, ug.GameId });

        builder.HasOne(ug => ug.User)
            .WithMany(u => u.UserGames)
            .HasForeignKey(ug => ug.UserId)
            .HasConstraintName("fk_user_games_user_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ug => ug.Game)
            .WithMany(g => g.UserGames)
            .HasForeignKey(ug => ug.GameId)
            .HasConstraintName("fk_user_games_game_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}