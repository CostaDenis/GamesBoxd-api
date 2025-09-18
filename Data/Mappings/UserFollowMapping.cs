using GamesBoxd_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesBoxd_api.Data.Mappings;

public class UserFollowMapping : IEntityTypeConfiguration<UserFollow>
{
    public void Configure(EntityTypeBuilder<UserFollow> builder)
    {
        builder.ToTable("users_follows");

        builder.HasKey(u => new { u.FollowerId, u.FolloweeId });

        builder.HasOne(u => u.Follower)
            .WithMany(user => user.Following)
            .HasForeignKey(u => u.FollowerId)
            .HasConstraintName("fk_userfollows_follower_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(u => u.Followee)
            .WithMany(user => user.Followers)
            .HasForeignKey(u => u.FolloweeId)
            .HasConstraintName("fk_userfollows_followee_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(u => u.IsBlocked)
            .HasColumnName("is_blocked")
            .HasColumnType("boolean")
            .IsRequired(true);

        builder.Property(u => u.Date)
            .HasColumnName("date")
            .HasColumnType("timestamptz")
            .IsRequired(true);
    }
}