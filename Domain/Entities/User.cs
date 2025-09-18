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
    public List<UserFollow> Followers { get; set; } = new();
    public List<UserFollow> Following { get; set; } = new();
    public List<UserGame> UserGames { get; set; } = new();
    public List<GameList> Lists { get; set; } = new();
}