using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Structured.Contracts.Responses;
using Structured.Mapping;
using Structured.Services;

namespace Structured.Endpoints;

[HttpGet("albums"), AllowAnonymous]
public class GetAllAlbumsEndpoint : EndpointWithoutRequest<GetAllAlbumsResponse>
{
    private readonly IAlbumService _albumService;

    public GetAllAlbumsEndpoint(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    public override async Task HandleAsync(CancellationToken token)
    {
        var albums = await _albumService.GetAllAsync();
        var albumsResponse = albums.ToAlbumsResponse();
        await SendOkAsync(albumsResponse, token);
    }
}