namespace GamesBoxd_api.Domain.Entities;

public class BacklogGame
{
    public Guid BacklogId { get; set; }
    public Backlog Backlog { get; set; } = default!;
    public Guid GameId { get; set; }
    public Game Game { get; set; } = default!;
}