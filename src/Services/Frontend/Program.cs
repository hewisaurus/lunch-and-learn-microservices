using Frontend.Models.Configuration;
using Frontend.Services;

var builder = WebApplication.CreateBuilder(args);

// Register the typed HTTP clients
builder.Services.AddHttpClient<IBackendService, BackendService>();

// Register peer API configuration
var apiConfiguration = new ApiConfiguration();
builder.Configuration.GetSection("ApiConfiguration").Bind(apiConfiguration);
builder.Services.AddSingleton(apiConfiguration);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
