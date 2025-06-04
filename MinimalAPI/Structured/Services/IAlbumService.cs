using Structured.Domain;

namespace Structured.Services;

public interface IAlbumService
{
    Task<bool> CreateAsync(Album album);

    Task<Album?> GetAsync(Guid id);

    Task<IEnumerable<Album>> GetAllAsync();

    Task<bool> UpdateAsync(Album album);

    Task<bool> DeleteAsync(Guid id);
}