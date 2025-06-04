namespace Structured.Domain;

public class Album()
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Title { get; init; }
    public string Artist { get; init; }
    public DateTime ReleaseDate { get; init; }
}