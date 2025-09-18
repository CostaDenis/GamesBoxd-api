namespace GamesBoxd_api.Domain.Entities;

public class Publisher
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public List<Game> Games { get; set; } = default!;
}