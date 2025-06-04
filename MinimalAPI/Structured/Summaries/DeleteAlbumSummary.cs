using FastEndpoints;
using Structured.Contracts.Responses;
using Structured.Endpoints;

namespace Structured.Summaries;

public class DeleteAlbumSummary : Summary<DeleteAlbumEndpoint>
{
    public DeleteAlbumSummary()
    {
        Summary = "Delete an album";
        Description = "Delete an album";
        Response(204, "Deleted album");
        Response(404, "Album not found");
    }
}