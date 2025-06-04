using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Structured.Contracts.Requests;
using Structured.Contracts.Responses;
using Structured.Mapping;
using Structured.Services;

namespace Structured.Endpoints;

[HttpPut("albums/{id:guid}"), AllowAnonymous]
public class UpdateAlbumEndpoint : Endpoint<UpdateAlbumRequest, AlbumResponse>
{
    private readonly IAlbumService _albumService;

    public UpdateAlbumEndpoint(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    public override async Task HandleAsync(UpdateAlbumRequest request, CancellationToken token)
    {
        var existingAlbum = await _albumService.GetAsync(request.Id);

        if (existingAlbum is null)
        {
            await SendNotFoundAsync(token);
            return;
        }

        var album = request.ToAlbum();
        await _albumService.UpdateAsync(album);

        var albumResponse = album.ToAlbumResponse();
        await SendOkAsync(albumResponse, token);
    }
}