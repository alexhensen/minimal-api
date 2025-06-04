using FastEndpoints;
using Structured.Contracts.Responses;
using Structured.Endpoints;

namespace Structured.Summaries;

public class GetAlbumSummary : Summary<GetAlbumEndpoint>
{
    public GetAlbumSummary()
    {
        Summary = "Get album by Id";
        Description = "Get album by Id";
        Response<AlbumResponse>(200, "Get all albums");
        Response<ValidationFailureResponse>(404, "Album not found");
    }
}