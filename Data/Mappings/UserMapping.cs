using GamesBoxd_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesBoxd_api.Data.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.Property(u => u.Id)
            .HasColumnName("id")
            .HasColumnType("uuid")
            .IsRequired(true);

        builder.Property(u => u.Email)
            .HasColumnName("email")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired(true);

        builder.HasIndex(u => u.Email)
            .IsUnique()
            .HasDatabaseName("ux_users_email");

        builder.Property(u => u.UserName)
            .HasColumnName("username")
            .HasColumnType("varchar")
            .HasMaxLength(25)
            .IsRequired(true);

        builder.HasIndex(u => u.UserName)
            .IsUnique()
            .HasDatabaseName("ux_users_username");

        builder.Property(u => u.Bio)
            .HasColumnName("bio")
            .HasColumnType("varchar")
            .HasMaxLength(300)
            .IsRequired(false);

        builder.Property(u => u.Image)
            .HasColumnName("image")
            .HasColumnType("varchar")
            .HasMaxLength(2048)
            .IsRequired(false);

        builder.HasMany(u => u.Reviews)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserId)
            .HasConstraintName("fk_reviews_user_id")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(true);

        builder.HasMany(u => u.Followers)
            .WithOne(uf => uf.Followee)
            .HasForeignKey(u => u.FolloweeId)
            .HasConstraintName("fk_userfollows_followee_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Following)
            .WithOne(uf => uf.Follower)
            .HasForeignKey(u => u.FollowerId)
            .HasConstraintName("fk_userfollows_follower_id")
            .OnDelete(DeleteBehavior.Cascade);

    }
}