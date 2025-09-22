namespace GamesBoxd_api.Domain.Entities;

public class Backlog
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public User User { get; set; } = default!;
    public List<BacklogGame> BacklogGames { get; set; } = default!;
}