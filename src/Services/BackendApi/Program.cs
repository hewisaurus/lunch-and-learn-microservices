using BackendApi.Models.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Use environment variables for content display - for demo purposes
var contentConfiguration = new ContentConfiguration();
builder.Configuration.GetSection("ContentConfiguration").Bind(contentConfiguration);
builder.Services.AddSingleton(contentConfiguration);

builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.UseHealthChecks("/health");

app.Run();
