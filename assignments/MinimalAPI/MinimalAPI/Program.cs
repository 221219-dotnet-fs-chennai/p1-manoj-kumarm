using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// creating a in memory database with the context class defined in the models project
builder.Services.AddDbContext<SongContext>(options => options.UseInMemoryDatabase("Songs"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// --HTTP POST method to create new data in the database using async and await
app.MapPost("/songs/create", async ([FromBody] Songs _song, SongContext _context) =>
{
    _context.Songs.Add(_song);
    await _context.SaveChangesAsync();
});

// --HTTP PUT method to update the data in the database using async and await
app.MapPut("/songs/{id}", async (int id, [FromBody] Songs _song, SongContext _context) =>
{
    var song = await _context.Songs.FindAsync(id);
    if (song == null) {
        return Results.NotFound();
    }
    else
    {
        song.SongId = _song.SongId;
        song.SongName = _song.SongName;
        await _context.SaveChangesAsync();
        return Results.NoContent();
    }
});

// --HTTP DELETE method to remove data from the database using async and await
app.MapDelete("/songs/{id}", async (int id, SongContext _context) => {
    if (await _context.Songs.FindAsync(id) is Songs _song)
    {
        _context.Remove(_song);
        _context.SaveChanges();
        return Results.Ok();
    }
    return Results.NotFound();
});

// --HTTP GET methods to fetch all the data and to fetch a single data by 
app.MapGet("/songs/all", async (SongContext _context) => await _context.Songs.ToListAsync());
app.MapGet("/songs/{id}", async (int id, SongContext _context) => await _context.Songs.FindAsync(id));

app.Run();

