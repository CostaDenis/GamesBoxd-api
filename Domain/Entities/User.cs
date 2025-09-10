namespace GamesBoxd_api.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string? Image { get; set; } = string.Empty;
    public string? Bio { get; set; }
    public ICollection<Review>? Reviews { get; set; }
    public ICollection<UserFollow> Followers { get; set; } = new HashSet<UserFollow>();
    public ICollection<UserFollow> Following { get; set; } = new HashSet<UserFollow>();
    public ICollection<UserGame> UserGames { get; set; } = new HashSet<UserGame>();
    public ICollection<GameList> Lists { get; set; } = new HashSet<GameList>();
}