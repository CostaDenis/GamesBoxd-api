namespace GamesBoxd_api.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ReviewId { get; set; }
    public Review Review { get; set; } = new();
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public int Likes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool? HasSpoiler { get; set; }
}