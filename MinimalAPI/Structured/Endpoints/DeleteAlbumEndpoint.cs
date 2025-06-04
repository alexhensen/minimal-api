using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Structured.Contracts.Requests;
using Structured.Services;

namespace Structured.Endpoints;

[HttpDelete("albums/{id:guid}"), AllowAnonymous]
public class DeleteAlbumEndpoint : Endpoint<DeleteAlbumRequest>
{
    private readonly IAlbumService _albumService;

    public DeleteAlbumEndpoint(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    public override async Task HandleAsync(DeleteAlbumRequest request, CancellationToken token)
    {
        var deleted = await _albumService.DeleteAsync(request.Id);
        if (!deleted)
        {
            await SendNotFoundAsync(token);
            return;
        }

        await SendNoContentAsync(token);
    }
}