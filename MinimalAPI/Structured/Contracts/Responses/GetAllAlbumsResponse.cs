namespace Structured.Contracts.Responses;

public class GetAllAlbumsResponse
{
    public IEnumerable<AlbumResponse> Albums { get; init; } = Enumerable.Empty<AlbumResponse>();
}