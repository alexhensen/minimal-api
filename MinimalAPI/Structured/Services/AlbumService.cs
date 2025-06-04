using FluentValidation;
using FluentValidation.Results;
using Structured.Domain;
using Structured.Mapping;
using Structured.Repositories;

namespace Structured.Services;

public class AlbumService(IAlbumRepository albumRepository) : IAlbumService
{
    private readonly IAlbumRepository _albumRepository = albumRepository;

    public async Task<bool> CreateAsync(Album album)
    {
        var existingAlbum = await _albumRepository.GetAsync(album.Id);
        if (existingAlbum is not null)
        {
            var message = $"An album with id {album.Id} already exists";
            throw new ValidationException(message, new []
            {
                new ValidationFailure(nameof(Album), message)
            });
        }

        var albumDto = album.ToAlbumDto();
        return await _albumRepository.CreateAsync(albumDto);
    }

    public async Task<Album?> GetAsync(Guid id)
    {
        var albumDto = await _albumRepository.GetAsync(id);
        return albumDto?.ToAlbum();
    }

    public async Task<IEnumerable<Album>> GetAllAsync()
    {
        var albumDtos = await _albumRepository.GetAllAsync();
        return albumDtos.Select(x => x.ToAlbum());
    }

    public async Task<bool> UpdateAsync(Album album)
    {
        var customerDto = album.ToAlbumDto();
        return await _albumRepository.UpdateAsync(customerDto);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _albumRepository.DeleteAsync(id);
    }
}