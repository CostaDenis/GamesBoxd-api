namespace GamesBoxd_api.Domain.Entities;

public class UserFriend
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public UserProfile User { get; set; } = default!;
    public Guid FriendId { get; set; }
    public UserProfile Friend { get; set; } = default!;
}