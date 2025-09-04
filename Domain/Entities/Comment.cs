namespace GamesBoxd_api.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public UserProfile User { get; set; } = default!;
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public int Likes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool? HasSpoiler { get; set; }
}