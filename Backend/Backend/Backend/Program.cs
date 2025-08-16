using Backend;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddMemoryCache();
builder.Services.ConfigureHttpClientDefaults(o => o.AddStandardResilienceHandler());
builder.Services.AddHttpClient<IGitHubService, GitHubService>(client =>
{
    client.BaseAddress = new Uri("https://api.github.com");
    client.DefaultRequestHeaders.UserAgent.ParseAdd("ZvooveCaseStudy/1.0");
});

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