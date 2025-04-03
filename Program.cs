using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseStaticFiles();

// API Endpoints
app.MapGet("/api/hello", (string? name) =>
{
    name ??= "World";
    return Results.Json(new
    {
        message = $"Hello, {name}!",
        timestamp = DateTime.UtcNow.ToString("o")
    });
})
.WithName("GetGreeting")
.WithOpenApi();

app.MapPost("/api/echo", (JsonElement body) =>
{
    return Results.Json(new
    {
        message = "Echo response",
        received = body,
        timestamp = DateTime.UtcNow.ToString("o")
    });
})
.WithName("EchoMessage")
.WithOpenApi();

// Serve the static index.html file
app.MapGet("/", () => Results.File("wwwroot/index.html", "text/html"))
   .WithName("GetIndex")
   .WithOpenApi();

// Start the application
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Run($"http://0.0.0.0:{port}");