using GamesBoxd_api.Domain.Enums;

namespace GamesBoxd_api.Domain.Entities;

public class Game
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public Developer Developer { get; set; } = default!;
    public Publisher Publisher { get; set; } = default!;
    public DateTime ReleaseDate { get; set; }
    public List<EGenre> Genres { get; set; } = new();
    public List<EPlatform> Platforms { get; set; } = new();
    public float AverageRating { get; set; }
    public List<UserGame> UserGames { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();

}