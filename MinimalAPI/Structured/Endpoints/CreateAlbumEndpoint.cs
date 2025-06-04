using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Structured.Contracts.Requests;
using Structured.Contracts.Responses;
using Structured.Mapping;
using Structured.Services;

namespace Structured.Endpoints;

[HttpPost("albums"), AllowAnonymous]
public class CreateAlbumEndpoint : Endpoint<CreateAlbumRequest, AlbumResponse>
{
    private readonly IAlbumService _albumService;
    
    public CreateAlbumEndpoint(IAlbumService albumService)
    {
        _albumService = albumService;
    }

    public override async Task HandleAsync(CreateAlbumRequest request, CancellationToken token)
    {
        var album = request.ToAlbum();

        await _albumService.CreateAsync(album);

        var response = album.ToAlbumResponse();

        await SendCreatedAtAsync<GetAlbumEndpoint>(new { Id = album.Id }, response, generateAbsoluteUrl: true,
            cancellation: token);
    }
}