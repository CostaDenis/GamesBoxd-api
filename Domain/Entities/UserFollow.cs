namespace GamesBoxd_api.Domain.Entities;

public class UserFollow
{
    public Guid FollowerId { get; set; }
    public User Follower { get; set; } = new();
    public Guid FolloweeId { get; set; }
    public User Followee { get; set; } = new();
    public bool IsBlocked { get; set; } = false;
    public DateTime Date { get; set; } = DateTime.UtcNow;
}