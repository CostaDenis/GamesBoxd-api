namespace GamesBoxd_api.Domain.Entities;

public class UserFollow
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid FollowerId { get; set; }
    public User Follower { get; set; } = default!;
    public Guid FolloweeId { get; set; }
    public User Followee { get; set; } = default!;
    public bool IsBlocked { get; set; } = false;
    public DateTime Date { get; set; } = DateTime.UtcNow;
}