namespace GamesBoxd_api.Domain.Entities;

public class Game
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public Guid DeveloperId { get; set; }
    public Developer Developer { get; set; } = new();
    public Guid PublisherId { get; set; }
    public Publisher Publisher { get; set; } = new();
    public DateTime ReleaseDate { get; set; }
    public List<Genre> Genres { get; set; } = new();
    public List<Platform> Platforms { get; set; } = new();
    public float AverageRating { get; set; }
    public List<UserGame> UserGames { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();

}