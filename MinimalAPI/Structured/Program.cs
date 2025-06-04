using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Structured.Contracts.Data;
using Structured.Contracts.Responses;
using Structured.Database;
using Structured.Domain;
using Structured.Repositories;
using Structured.Services;
using Structured.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddFastEndpoints()
    .SwaggerDocument();

builder.Services.AddDbContext<AlbumDbContext>(opt => opt.UseInMemoryDatabase("AlbumsDb"));

builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IAlbumService, AlbumService>();

var app = builder.Build();

app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseFastEndpoints().UseSwaggerGen();



using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<AlbumDbContext>();

    // Ensure the database is created. This is useful for in-memory databases.
    context?.Database.EnsureCreated();

    // Check if the database is already seeded
    if (context != null && !context.Albums.Any())
    {
        context.Albums.AddRange(
            new AlbumDto { Title = "Taylor Swift", Artist = "Taylor Swift", ReleaseDate = new DateTime(2006, 10, 24) },
            new AlbumDto { Title = "Fearless", Artist = "Taylor Swift", ReleaseDate = new DateTime(2008, 11, 11) },
            new AlbumDto { Title = "Speak Now", Artist = "Taylor Swift", ReleaseDate = new DateTime(2010, 10, 25) },
            new AlbumDto { Title = "Red", Artist = "Taylor Swift", ReleaseDate = new DateTime(2012, 10, 22) },
            new AlbumDto { Title = "1989", Artist = "Taylor Swift", ReleaseDate = new DateTime(2014, 10, 27) },
            new AlbumDto { Title = "Reputation", Artist = "Taylor Swift", ReleaseDate = new DateTime(2017, 11, 10) },
            new AlbumDto { Title = "Lover", Artist = "Taylor Swift", ReleaseDate = new DateTime(2019, 8, 23) },
            new AlbumDto { Title = "Folklore", Artist = "Taylor Swift", ReleaseDate = new DateTime(2020, 7, 24) },
            new AlbumDto { Title = "Evermore", Artist = "Taylor Swift", ReleaseDate = new DateTime(2020, 12, 11) },
            new AlbumDto { Title = "Midnight", Artist = "Taylor Swift",  ReleaseDate = new DateTime(2022, 10, 21) }
            // Add future albums here
        );
        context.SaveChanges();
    }
}


//var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
//await databaseInitializer.InitializeAsync();

app.Run();