using GamesBoxd_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesBoxd_api.Data.Mappings;

public class ReviewMapping : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("reviews");

        builder.Property(r => r.Id)
            .HasColumnName("id")
            .HasColumnType("uuid")
            .IsRequired(true);

        builder.HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId)
            .HasConstraintName("fk_reviews_user_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Game)
            .WithMany(g => g.Reviews)
            .HasForeignKey(r => r.GameId)
            .HasConstraintName("fk_reviews_game_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.MainComment)
            .WithMany()
            .HasForeignKey(r => r.MainCommentId)
            .HasConstraintName("fk_reviews_main_comment_id")
            .OnDelete(DeleteBehavior.SetNull)
            .IsRequired(false);

        builder.Property(r => r.Rating)
            .HasColumnName("rating")
            .HasColumnType("numeric(2,1)")
            .IsRequired();

        builder.Property(r => r.Likes)
            .HasColumnName("likes")
            .HasColumnType("integer")
            .IsRequired(true);

        builder.HasMany(r => r.Comments)
            .WithOne(c => c.Review)
            .HasForeignKey(c => c.ReviewId)
            .HasConstraintName("fk_comment_review_id")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        builder.Property(r => r.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamptz")
            .IsRequired();
    }
}