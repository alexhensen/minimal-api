using Structured.Contracts.Responses;
using Structured.Domain;

namespace Structured.Mapping;

public static class DomainToApiContractMapper
{
    public static AlbumResponse ToAlbumResponse(this Album album)
    {
        return new AlbumResponse
        {
            Id = album.Id,
            Artist = album.Artist,
            ReleaseDate = album.ReleaseDate,
            Title = album.Title
        };
    }

    public static GetAllAlbumsResponse ToAlbumsResponse(this IEnumerable<Album> albums)
    {
        return new GetAllAlbumsResponse
        {
            Albums = albums.Select(a => new AlbumResponse
            {
               Id = a.Id,
               Artist = a.Artist,
               ReleaseDate = a.ReleaseDate,
               Title = a.Title
            })
        };
    }
}