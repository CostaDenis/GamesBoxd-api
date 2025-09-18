using GamesBoxd_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesBoxd_api.Data.Mappings;

public class GameListMapping : IEntityTypeConfiguration<GameList>
{
    public void Configure(EntityTypeBuilder<GameList> builder)
    {
        builder.ToTable("game_list");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id)
            .HasColumnName("id")
            .HasColumnType("uuid")
            .IsRequired(true);

        builder.Property(g => g.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(30)
            .IsRequired(true);

        builder.Property(g => g.Description)
            .HasColumnName("description")
            .HasColumnType("varchar")
            .HasMaxLength(200)
            .IsRequired(false);

        builder.HasOne(gl => gl.User)
            .WithMany(u => u.Lists)
            .HasForeignKey(gl => gl.UserId)
            .HasConstraintName("fk_gamelist_user_id")
            .OnDelete(DeleteBehavior.Cascade);

        //Relacionamento de GameList(n) : (n)Game
        builder.HasMany(gl => gl.Games)
            .WithMany(g => g.Lists)
            .UsingEntity<Dictionary<string, object>>(
                "gamelist_game",

                glg =>
                    glg.HasOne<Game>()
                        .WithMany()
                        .HasForeignKey("game_id")
                        .HasConstraintName("fk_gamelist_game_game_id"),

                glg =>
                    glg.HasOne<GameList>()
                        .WithMany()
                        .HasForeignKey("gamelist_id")
                        .HasConstraintName("fk_gamelist_game_gamelist_id"),

                glg =>
                {
                    glg.ToTable("gamelist_game");

                    glg.HasKey("gamelist_id", "game_id")
                        .HasName("pk_gamelist_game");

                    glg.HasIndex("gamelist_id");

                    glg.HasIndex("game_id");
                }

            );

        builder.Property(g => g.Likes)
            .HasColumnName("likes")
            .HasColumnType("integer")
            .HasDefaultValue(0)
            .IsRequired();

        builder.HasMany(g => g.Comments)
            .WithOne(c => c.GameList)
            .HasForeignKey(c => c.GameListId)
            .HasConstraintName("fk_comments_gamelist_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}