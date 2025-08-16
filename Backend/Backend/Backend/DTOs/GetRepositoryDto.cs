using Backend.Models;

namespace Backend.DTOs;

public sealed record GetRepositoryDto
{
    /// <summary>Gets or sets the name of the repository.</summary>
    public string Name { get; init; } = "";

    /// <summary>Gets or sets the description of the repository.</summary>
    public string Description { get; init; } = "";

    /// <summary>Gets or sets the number of stars the repository has.</summary>
    public int Stars { get; init; }

    /// <summary>Gets or sets the primary programming language of the repository.</summary>
    public string? PrimaryLanguage { get; init; }

    /// <summary>Gets or sets the score of the repository.</summary>
    public double Score { get; init; }

    /// <summary>Maps a <see cref="Repository" /> object to a <see cref="GetRepositoryDto" /> object.</summary>
    public static GetRepositoryDto FromRepository(Repository repository)
    {
        return new GetRepositoryDto
        {
            Name = repository.Name,
            Description = repository.Description,
            Stars = repository.Stars,
            PrimaryLanguage = repository.PrimaryLanguage,
            Score = repository.CalculateScore()
        };
    }
}