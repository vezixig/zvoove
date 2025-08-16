using Backend.DTOs;

namespace Backend;

public interface IRepositoryService
{
    Task<List<GetRepositoryDto>> GetTrendingRepositoriesAsync();
}

internal sealed class RepositoryService(IGitHubService service) : IRepositoryService
{
    public async Task<List<GetRepositoryDto>> GetTrendingRepositoriesAsync()
    {
        var repositories = await service.GetTrendingRepositoriesAsync();
        return repositories
            .Select(GetRepositoryDto.FromRepository)
            .OrderByDescending(o => o.Score)
            .ToList();
    }
}