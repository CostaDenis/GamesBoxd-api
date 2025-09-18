namespace GamesBoxd_api.Domain.Entities;

public class GameList
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = new();
    public List<Game> Games { get; set; } = new();
    public int Likes { get; set; }
    public List<Comment>? Comments { get; set; }
}