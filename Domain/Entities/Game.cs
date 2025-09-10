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
    public ICollection<EGenre> Genres { get; set; } = new HashSet<EGenre>();
    public ICollection<EPlatform> Platforms { get; set; } = new HashSet<EPlatform>();
    public float AverageRating { get; set; }
    public ICollection<UserGame> UserGames { get; set; } = new HashSet<UserGame>();
    public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

}