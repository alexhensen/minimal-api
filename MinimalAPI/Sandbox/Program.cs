using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI;

var builder = WebApplication.CreateBuilder(args);

// Configure Services

builder.Services.AddScoped<ITestService, TestService>();

var app = builder.Build();

app.MapGet("hello", () => "Hello World");

app.MapGet("helloobj", () => new { Hello = "Delegate" });

app.MapGet("album", () => new Album(1, "artis", "albumtitle"));

app.MapGet("artist/{artist}", (string artist) => new Album(0, artist, "title"));

app.MapGet("album/{id:int}", (int id) => new Album(id, "artist", "title"));

app.MapGet("album/{title}", (string title, string artist) => new Album(0, artist, title));

app.MapPost("parameters/{id:int}",([AsParameters]SomeRequest request) => new { Id = request.id, Title = request.title, User = request.user, Test = request.testService.Hello()});


// Configure app

app.Run();

record Album(int id, string Artist, string AlbumTitle);

record User(string name);

record SomeRequest(int id, [FromQuery(Name="a")]string title, [FromBody]User user, ITestService testService);