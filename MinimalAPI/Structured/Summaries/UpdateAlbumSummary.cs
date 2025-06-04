using FastEndpoints;
using Structured.Contracts.Responses;
using Structured.Endpoints;

namespace Structured.Summaries;

public class UpdateAlbumSummary : Summary<UpdateAlbumEndpoint>
{
    public UpdateAlbumSummary()
    {
        Summary = "Updates an album";
        Description = "Updates an album";
        Response<AlbumResponse>(201, "Album updated");
        Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
    }
}