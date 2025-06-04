using Reaper.Attributes;
using Reaper.Requests;
using Reaper.Responses;
using Reaper.Services;

namespace Reaper.Endpoints;

[ReaperRoute(HttpVerbs.Post, "reflector")]
public class AlbumEndpoint (IAlbumService service) : ReaperEndpoint<AlbumRequest, AlbumResponse>
{
    public override async Task ExecuteAsync(AlbumRequest request)
    {
        Result = new AlbumResponse()
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Artist = "Unknown Artist",
            ReleaseDate = DateTime.UtcNow
        };
    }
}