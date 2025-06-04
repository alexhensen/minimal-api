using Structured.Contracts.Data;

namespace Structured.Repositories;

public interface IAlbumRepository
{
    Task<bool> CreateAsync(AlbumDto album);

    Task<AlbumDto?> GetAsync(Guid id);

    Task<IEnumerable<AlbumDto>> GetAllAsync();

    Task<bool> UpdateAsync(AlbumDto album);

    Task<bool> DeleteAsync(Guid id);
}