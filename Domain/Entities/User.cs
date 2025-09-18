namespace GamesBoxd_api.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string? Bio { get; set; }
    public string? Image { get; set; }
    public List<Review>? Reviews { get; set; }
    public List<UserFollow> Followers { get; set; } = default!;
    public List<UserFollow> Following { get; set; } = default!;
    public List<UserGame> UserGames { get; set; } = default!;
    public List<GameList> Lists { get; set; } = default!;
}