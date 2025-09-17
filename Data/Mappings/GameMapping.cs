using GamesBoxd_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;

namespace GamesBoxd_api.Data.Mappings;

public class GameMapping : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.ToTable("games");

        builder.Property(g => g.Id)
            .HasColumnName("id")
            .HasColumnType("uuid")
            .IsRequired(true);

        builder.Property(g => g.Name)
            .HasColumnName("name")
            .HasColumnType("varchar")
            .HasMaxLength(80)
            .IsRequired(true);

        builder.Property(g => g.Image)
            .HasColumnName("image")
            .HasColumnType("varchar")
            .HasMaxLength(2048)
            .IsRequired(true);

        builder.Property(g => g.Bio)
            .HasColumnName("bio")
            .HasColumnType("varchar")
            .HasMaxLength(1024)
            .IsRequired(true);

        // builder.OwnsOne(g => g.Developer, developer =>
        // {
        //     developer.Property(d => d.Id)
        //     .HasColumnName("id")
        //     .HasColumnType("uuid")
        //     .IsRequired(true);

        //     developer.Property(d => d.Name)
        //     .HasColumnName("name")
        //     .HasColumnType("varchar")
        //     .HasMaxLength(80)
        //     .IsRequired(true);

        //     developer.HasIndex(d => d.Name)
        //     .IsUnique()
        //     .HasDatabaseName("idx_games_developer_name");
        // });

        builder.Property(g => g.DeveloperId)
            .HasColumnName("developer_id")
            .HasColumnType("uuid")
            .IsRequired(true);

        builder.HasOne(g => g.Developer)
            .WithMany(d => d.Games)
            .HasForeignKey(g => g.DeveloperId)
            .HasConstraintName("fk_games_developer_id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(g => g.PublisherId)
            .HasColumnName("publisher_id")
            .HasColumnType("uuid")
            .IsRequired(true);

        builder.HasOne(g => g.Publisher)
            .WithMany(p => p.Games)
            .HasForeignKey(g => g.PublisherId)
            .HasConstraintName("fk_games_publisher_id")
            .OnDelete(DeleteBehavior.Restrict);

        // builder.OwnsOne(g => g.Publisher, publisher =>
        // {
        //     publisher.Property(p => p.Id)
        //     .HasColumnName("id")
        //     .HasColumnType("uuid")
        //     .IsRequired(true);

        //     publisher.Property(p => p.Name)
        //     .HasColumnName("name")
        //     .HasColumnType("varchar")
        //     .HasMaxLength(80)
        //     .IsRequired(true);

        //     publisher.HasIndex(d => d.Name)
        //     .IsUnique()
        //     .HasDatabaseName("idx_games_publisher_name");
        // });

        builder.Property(g => g.ReleaseDate)
            .HasColumnName("release_date")
            .HasColumnType("timestamptz")
            .IsRequired();

        //Relacionamento de Game (n) : (n) Genre
        builder.HasMany(g => g.Genres)
            .WithMany(e => e.Games)
            .UsingEntity<Dictionary<string, object>>(
                "game_genre",

                gg => gg.HasOne<Genre>()
                        .WithMany()
                        .HasForeignKey("genre_id")
                        .HasConstraintName("fk_game_genre_genre_id")
                        .OnDelete(DeleteBehavior.Cascade),

                gg => gg.HasOne<Game>()
                        .WithMany()
                        .HasForeignKey("game_id")
                        .HasConstraintName("fk_game_genre_game_id")
                        .OnDelete(DeleteBehavior.Cascade),

                gg =>
                {
                    gg.ToTable("game_genre");
                    gg.HasKey("game_id", "genre_id");
                    gg.HasIndex("game_id");
                    gg.HasIndex("genre_id");
                }
            );

        //Relacionamento de Game (n) : (n) Platform
        builder.HasMany(g => g.Platforms)
            .WithMany(p => p.Games)
            .UsingEntity<Dictionary<string, object>>(
                "game_platform",

                gp => gp.HasOne<Platform>()
                        .WithMany()
                        .HasForeignKey("platform_id")
                        .HasConstraintName("fk_game_platform_platform_id")
                        .OnDelete(DeleteBehavior.Cascade),

                gp => gp.HasOne<Game>()
                        .WithMany()
                        .HasForeignKey("game_id")
                        .HasConstraintName("fk_game_platform_game_id")
                        .OnDelete(DeleteBehavior.Cascade),

                gg =>
                {
                    gg.ToTable("game_platform");
                    gg.HasKey("game_id", "platform_id");
                    gg.HasIndex("game_id");
                    gg.HasIndex("platform_id");
                }
            );

        builder.Property(g => g.AverageRating)
            .HasColumnName("average_rating")
            .HasColumnType("numeric(3,2)");

        builder.HasMany(g => g.UserGames)
            .WithOne(ug => ug.Game)
            .HasForeignKey(ug => ug.GameId)
            .HasConstraintName("fk_user_games_game_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}