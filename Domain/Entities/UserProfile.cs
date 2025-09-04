namespace GamesBoxd_api.Domain.Entities;

public class UserProfile
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string? Image { get; set; } = string.Empty;
    public string? Bio { get; set; }
    public List<Review>? Reviews { get; set; } = new();
    public List<UserFriend> Friends { get; set; } = new();
    public List<UserGame> UserGames { get; set; } = new();
    public List<GameList> Lists { get; set; } = new();
}