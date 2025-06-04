namespace Structured.Contracts.Requests;

public class CreateAlbumRequest
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Artist { get; init; }
    public DateTime ReleaseDate { get; init; }
}