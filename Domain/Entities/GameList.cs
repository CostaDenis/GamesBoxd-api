namespace GamesBoxd_api.Domain.Entities;

public class GameList
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = default!;
    public int Likes { get; set; }
    public ICollection<Comment>? Comments { get; set; }
}