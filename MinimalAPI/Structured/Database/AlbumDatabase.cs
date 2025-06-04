using Microsoft.EntityFrameworkCore;
using Structured.Contracts.Data;

namespace Structured.Database;

public class AlbumDbContext(DbContextOptions<AlbumDbContext> options) : DbContext(options)
{
    public DbSet<AlbumDto> Albums => Set<AlbumDto>();
}