namespace GamesBoxd_api.Domain.Entities;

public class GameList
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid UserId { get; set; }
    public UserProfile User { get; set; } = default!;
    public int Likes { get; set; }
    public List<Comment> Comments { get; set; } = new();
}