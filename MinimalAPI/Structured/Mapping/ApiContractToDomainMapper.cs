using Structured.Contracts.Requests;
using Structured.Domain;

namespace Structured.Mapping;

public static class ApiContractToDomainMapper
{
    public static Album ToAlbum(this CreateAlbumRequest request)
    {
        return new Album
        {
            Id = Guid.NewGuid(),
            Artist = request.Artist,
            ReleaseDate = request.ReleaseDate,
            Title = request.Title
        };
    }

    public static Album ToAlbum(this UpdateAlbumRequest request)
    {
        return new Album
        {
            Id = request.Id,
            Artist = request.Artist,
            ReleaseDate = request.ReleaseDate,
            Title = request.Title
        };
    }
}