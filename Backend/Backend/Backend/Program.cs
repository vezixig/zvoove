using Backend;
using Backend.DTOs;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddMemoryCache();
builder.Services.ConfigureHttpClientDefaults(o => o.AddStandardResilienceHandler());
builder.Services.AddTransient<IRepositoryService, RepositoryService>();
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

app.MapGet("/repositories", async (IRepositoryService repositoryService) =>
    {
        var repositories = await repositoryService.GetTrendingRepositoriesAsync();
        return repositories.Count == 0
            ? Results.NotFound("No trending repositories found.")
            : Results.Ok(repositories);
    })
    .WithName("Get Trending Repositories")
    .WithDescription("Fetches the first 100 trending repositories")
    .Produces<List<GetRepositoryDto>>()
    .Produces<string>(StatusCodes.Status404NotFound, "application/json");

app.Run();