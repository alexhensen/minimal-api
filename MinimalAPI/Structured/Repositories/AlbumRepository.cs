using Microsoft.EntityFrameworkCore;
using Structured.Contracts.Data;
using Structured.Database;

namespace Structured.Repositories;

public class AlbumRepository(AlbumDbContext context) : IAlbumRepository
{
    private readonly AlbumDbContext _context = context;
    
    public async Task<bool> CreateAsync(AlbumDto album)
    {
        _context.Albums.Add(album);
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<AlbumDto?> GetAsync(Guid id)
    {
        return await _context.Albums.FindAsync(id);
    }

    public async Task<IEnumerable<AlbumDto>> GetAllAsync()
    {
        return await _context.Albums.ToListAsync();
    }

    public async Task<bool> UpdateAsync(AlbumDto album)
    {
        _context.Entry(album).State = EntityState.Modified;
        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        bool result = false;
        
        var album = await _context.Albums.FindAsync(id);
        if (album != null)
        {
            _context.Albums.Remove(album);
            result = await _context.SaveChangesAsync() > 0;
        }

        return result;
    }
}