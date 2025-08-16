namespace Backend.DTOs;

public sealed record GetRepositoryDto
{
    /// <summary>
    ///     Gets or sets the name of the repository.
    /// </summary>
    public string Name { get; init; } = "";

    /// <summary>
    ///     Gets or sets the description of the repository.
    /// </summary>
    public string Description { get; init; } = "";

    /// <summary>
    ///     Gets or sets the number of stars the repository has.
    /// </summary>
    public int Stars { get; init; }

    /// <summary>
    ///     Gets or sets the primary programming language of the repository.
    /// </summary>
    public string PrimaryLanguage { get; init; } = "";
}