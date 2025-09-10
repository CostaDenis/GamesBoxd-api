namespace GamesBoxd_api.Domain.Entities;

public class UserFriend
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public User User { get; set; } = default!;
    public Guid FriendId { get; set; }
    public User Friend { get; set; } = default!;
}