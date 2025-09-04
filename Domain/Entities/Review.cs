namespace GamesBoxd_api.Domain.Entities;

public class Review
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public UserProfile User { get; set; } = default!;
    public Guid GameId { get; set; }
    public Game Game { get; set; } = default!;
    public Comment? Comment { get; set; }
    public float Rating { get; set; }
    public int Likes { get; set; }
    public List<Comment>? Comments { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}