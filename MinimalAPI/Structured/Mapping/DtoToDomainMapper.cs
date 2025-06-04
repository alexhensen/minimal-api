using Structured.Contracts.Data;
using Structured.Contracts.Requests;
using Structured.Domain;

namespace Structured.Mapping;

public static class DtoToDomainMapper
{
    public static Album ToAlbum(this AlbumDto albumDto)
    {
        return new Album
        {
            Id = albumDto.Id,
            Artist = albumDto.Artist,
            ReleaseDate = albumDto.ReleaseDate,
            Title = albumDto.Title
        };
    }
}