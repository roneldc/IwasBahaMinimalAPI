using IwasBahaAPI.Data;
using IwasBahaAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=roadstatus.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()      // allow all clients (you can restrict later)
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add services to the container.

var app = builder.Build();

app.UseCors("AllowAll");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate(); // applies migrations
    DbSeeder.Seed(db);     // seeds initial data
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/updates", async (AppDbContext db) =>
{
    var updates = await db.RoadStatusUpdates
    .Include(u => u.Statuses)
        .ThenInclude(s => s.Roads)
    .Select(u => new RoadStatusUpdate
    {
        Id = u.Id,
        City = u.City,
        ReportedAt = u.ReportedAt,
        Statuses = u.Statuses
            .OrderBy(s => s.Condition)
            .ThenBy(s => s.Barangay)
            .Select(s => new RoadStatus
            {
                Id = s.Id,
                Condition = s.Condition,
                Barangay = s.Barangay,
                RoadStatusUpdateId = s.RoadStatusUpdateId,
                Roads = s.Roads
                    .OrderBy(r => r.Name)
                    .ToList()
            })
            .ToList()
    })
    .OrderBy(u => u.City) // 👈 Order by City at the root level
    .ToListAsync();

    return Results.Ok(updates);
});

app.MapPost("/api/updates", async (AppDbContext db, RoadStatusUpdate update) =>
{
    db.RoadStatusUpdates.Add(update);
    await db.SaveChangesAsync();
    return Results.Created($"/api/updates/{update.Id}", update);
});

app.MapGet("/api/updates/{id}", async (AppDbContext db, int id) =>
    await db.RoadStatusUpdates
        .Include(u => u.Statuses)
        .ThenInclude(s => s.Roads)
        .FirstOrDefaultAsync(u => u.Id == id)
        is RoadStatusUpdate update
        ? Results.Ok(update)
        : Results.NotFound());

app.MapGet("/", () => "Hello from Railway!");

// Get port from environment variable (provided by Railway)
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

// Listen on all IP addresses on that port
app.Urls.Add($"http://*:{port}");

app.Run();