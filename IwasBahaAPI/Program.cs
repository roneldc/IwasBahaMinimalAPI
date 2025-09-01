using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
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

// --- Initialize Firebase ---
var firebaseBase64 = builder.Configuration["FIREBASE_CONFIG_BASE64"];
if (!string.IsNullOrEmpty(firebaseBase64))
{
    var jsonBytes = Convert.FromBase64String(firebaseBase64);
    using var stream = new MemoryStream(jsonBytes);

    if (FirebaseApp.DefaultInstance == null)
    {
        FirebaseApp.Create(new AppOptions
        {
            Credential = GoogleCredential.FromStream(stream)
        });
        Console.WriteLine("Firebase initialized from Base64.");
    }
}
else
{
    Console.WriteLine("Firebase Base64 not found!");
}


//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//    // Clear child tables first (because of FK constraints)
//    context.Roads.RemoveRange(context.Roads);
//    context.RoadStatuses.RemoveRange(context.RoadStatuses);
//    context.RoadStatusUpdates.RemoveRange(context.RoadStatusUpdates);
//    context.SaveChanges();

//    // Reset identity/autoincrement
//    context.Database.ExecuteSqlRaw("DELETE FROM sqlite_sequence WHERE name IN ('Roads','RoadStatuses','RoadStatusUpdates')");
//}

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
        .ToListAsync(); // materialize first (EF → objects)

    var result = updates
        .OrderBy(u => u.City)
        .Select(u => new
        {
            u.Id,
            u.City,
            u.ReportedAt,
            Barangays = u.Statuses
                .GroupBy(s => s.Barangay)
                .OrderBy(g => g.Key)
                .Select(g => new
                {
                    Barangay = g.Key,
                    Statuses = g
                        .OrderBy(s => s.Condition)
                        .Select(s => new
                        {
                            s.Id,
                            s.Condition,
                            Roads = s.Roads
                                .OrderBy(r => r.Name)
                                .Select(r => new { r.Id, r.Name })
                                .ToList()
                        })
                        .ToList()
                })
                .ToList()
        })
        .ToList();

    return Results.Ok(result);
});


// POST endpoint to add updates + send notification
app.MapPost("/api/updates", async (AppDbContext db, RoadStatusUpdate update) =>
{
    db.RoadStatusUpdates.Add(update);
    await db.SaveChangesAsync();

    // ✅ Send push notification
    var message = new Message()
    {
        Notification = new Notification
        {
            Title = $"🚨 {update.City} Update",
            Body = $"New road status reported at {update.ReportedAt:g}"
        },
        Topic = "roadupdates"  // you can also target a specific device token
    };

    try
    {
        string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
        Console.WriteLine($"Successfully sent notification: {response}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error sending notification: {ex.Message}");
    }

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

app.MapPost("/api/notify", async (string title, string body) =>
{
    if (FirebaseApp.DefaultInstance == null)
        return Results.Problem("Firebase is not initialized.");

    var message = new Message
    {
        Notification = new Notification
        {
            Title = title,
            Body = body
        },
        Topic = "roadupdates"
    };

    try
    {
        string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
        return Results.Ok($"Notification sent! ID: {response}");
    }
    catch (Exception ex)
    {
        return Results.Problem($"Error sending notification: {ex.Message}");
    }
});


app.Run();