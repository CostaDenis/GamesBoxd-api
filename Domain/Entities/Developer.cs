namespace GamesBoxd_api.Domain.Entities;

public class Developer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public List<Game> Games { get; set; } = default!;
}