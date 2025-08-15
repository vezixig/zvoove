using System.Text.Json;
using Backend.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Backend;

public interface IGitHubService
{
    public Task<List<Repository>> GetTrendingRepositoriesAsync();
}

internal sealed class GitHubService(IMemoryCache memoryCache, HttpClient httpClient) : IGitHubService
{
    private const string GitHubApiBaseUrl = "https://api.github.com";
    private const string RepositorySearchEndpoint = "/search/repositories";
    private const string RepositoryQueryParams = "q=created:<TODAY fork:false&sort=stars&order=desc&per_page=100";

    private const string CacheKey = "TrendingRepositories";
    private const int CacheDurationHours = 6;


    public async Task<List<Repository>> GetTrendingRepositoriesAsync()
    {
        if (memoryCache.TryGetValue(CacheKey, out List<Repository>? cachedRepositories))
            return cachedRepositories ?? [];

        var uri = new UriBuilder(GitHubApiBaseUrl)
        {
            Path = RepositorySearchEndpoint,
            Query = RepositoryQueryParams.Replace("TODAY", DateTime.UtcNow.ToString("yyyy-MM-dd"))
        }.Uri;

        // add user agent header to comply with GitHub API requirements
        httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("ZvooveCaseStudy/1.0");

        var response = await httpClient.GetAsync(uri);
        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException($"Failed to fetch trending repositories: {response.ReasonPhrase}");

        var content = await response.Content.ReadAsStringAsync();
        var searchRepositoryResponse = JsonSerializer.Deserialize<SearchRepositoryResponse>(content);
        if (searchRepositoryResponse == null)
            throw new InvalidOperationException("Failed to deserialize the response from GitHub API.");

        var repositories = MapRepositories(searchRepositoryResponse);

        memoryCache.Set(CacheKey, repositories, TimeSpan.FromHours(CacheDurationHours));
        return repositories;
    }

    private static List<Repository> MapRepositories(SearchRepositoryResponse searchRepositoryResponse)
    {
        var repositories = searchRepositoryResponse.Items.Select(item => new Repository
        {
            Name = item.Name,
            Description = item.Description,
            Stars = item.StargazersCount,
            Forks = item.ForksCount
        }).ToList();
        return repositories;
    }
}