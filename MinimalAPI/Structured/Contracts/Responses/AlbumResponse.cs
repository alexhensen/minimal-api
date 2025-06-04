namespace Structured.Contracts.Responses;

public class AlbumResponse
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Artist { get; init; }
    public DateTime ReleaseDate { get; init; }
}