using Structured.Contracts.Data;
using Structured.Domain;

namespace Structured.Mapping;

public static class DomainToDtoMapper
{
    public static AlbumDto ToAlbumDto(this Album album)
    {
        return new AlbumDto
        {
            Id = album.Id,
            Artist = album.Artist,
            ReleaseDate = album.ReleaseDate,
            Title = album.Title
        };
    }
}