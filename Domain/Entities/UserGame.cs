namespace GamesBoxd_api.Domain.Entities;

public class UserGame
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public User User { get; set; } = default!;
    public Guid GameId { get; set; }
    public Game Game { get; set; } = default!;

}