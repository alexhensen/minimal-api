using FastEndpoints;
using Structured.Contracts.Responses;
using Structured.Endpoints;

namespace Structured.Summaries;

public class CreateAlbumSummary : Summary<CreateAlbumEndpoint>
{
    public CreateAlbumSummary()
    {
        Summary = "Creates a new album";
        Description = "Creates a new album";
        Response<AlbumResponse>(201, "Album created");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}