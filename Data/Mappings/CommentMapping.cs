using GamesBoxd_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesBoxd_api.Data.Mappings;

public class CommentMapping : IEntityTypeConfiguration<Comment>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("comments");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id")
            .HasColumnType("uuid")
            .IsRequired(true);

        builder.HasOne(c => c.Review)
            .WithMany(r => r.Comments)
            .HasForeignKey(c => c.ReviewId)
            .HasConstraintName("fk_comments_review_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(c => c.Title)
            .HasColumnName("title")
            .HasColumnType("varchar")
            .HasMaxLength(30)
            .IsRequired(true);

        builder.Property(c => c.Text)
            .HasColumnName("text")
            .HasColumnType("varchar")
            .HasMaxLength(1024)
            .IsRequired(true);

        builder.Property(c => c.Likes)
            .HasColumnName("likes")
            .HasColumnType("integer")
            .HasDefaultValue(0)
            .IsRequired(true);

        builder.Property(c => c.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamptz")
            .IsRequired(true);

        builder.Property(c => c.HasSpoiler)
            .HasColumnName("has_spoiler")
            .HasColumnType("boolean")
            .IsRequired(false);
    }
}