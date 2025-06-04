using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Structured.Contracts.Data;
using Structured.Contracts.Requests;
using Structured.Contracts.Responses;
using Structured.Mapping;
using Structured.Services;

namespace Structured.Endpoints;

[HttpGet("albums/{id:guid}"), AllowAnonymous]
public class GetAlbumEndpoint : Endpoint<GetAlbumRequest, AlbumResponse>
{
    private readonly IAlbumService _albumService;

    public GetAlbumEndpoint(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    public override async Task HandleAsync(GetAlbumRequest request, CancellationToken token)
    {
        var album = await _albumService.GetAsync(request.Id);

        if (album is null)
        {
            await SendNotFoundAsync(token);
            return;
        }

        var albumResponse = album.ToAlbumResponse();
        await SendOkAsync(albumResponse, token);
    }
}