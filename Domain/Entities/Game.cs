namespace GamesBoxd_api.Domain.Entities;

public class Game
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public Guid DeveloperId { get; set; }
    public Developer Developer { get; set; } = default!;
    public Guid PublisherId { get; set; }
    public Publisher Publisher { get; set; } = default!;
    public DateTime ReleaseDate { get; set; }
    public List<Genre> Genres { get; set; } = default!;
    public List<Platform> Platforms { get; set; } = default!;
    public float AverageRating { get; set; }
    public List<GameList> Lists { get; set; } = default!;
    public List<UserGame> UserGames { get; set; } = default!;
    public List<Review> Reviews { get; set; } = default!;
    public List<BacklogGame> BacklogGames { get; set; } = default!;

}