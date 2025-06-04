using FastEndpoints;
using Structured.Contracts.Responses;
using Structured.Endpoints;

namespace Structured.Summaries;

public class GetAllAlbumsSummary : Summary<GetAllAlbumsEndpoint>
{
    public GetAllAlbumsSummary()
    {
        Summary = "Get all albums";
        Description = "Get all albums";
        Response<GetAllAlbumsResponse>(201, "Get all albums");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}