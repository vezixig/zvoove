using Backend.DTOs;

namespace Backend;

public interface IRepositoryService
{
    Task<List<GetRepositoryDto>> GetTrendingRepositoriesAsync(string filter);
}

internal sealed class RepositoryService(IGitHubService service) : IRepositoryService
{
    public async Task<List<GetRepositoryDto>> GetTrendingRepositoriesAsync(string filter)
    {
        var repositories = await service.GetTrendingRepositoriesAsync(filter);
        return repositories
            .Select(GetRepositoryDto.FromRepository)
            .OrderByDescending(o => o.Score)
            .ToList();
    }
}