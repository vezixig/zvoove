using Backend;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddHttpClient();
builder.Services.AddMemoryCache();
builder.Services.AddTransient<IGitHubService, GitHubService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", async (IGitHubService githubService) =>
    {
        var test = await githubService.GetTrendingRepositoriesAsync();
        return test;
    })
    .WithName("GetWeatherForecast");

app.Run();