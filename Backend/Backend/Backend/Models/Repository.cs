namespace Backend.Models;

/// <summary>
///     Represents a GitHub repository.
/// </summary>
public sealed class Repository
{
    /// <summary>
    ///     Gets or sets the name of the repository.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    ///     Gets or sets the description of the repository.
    /// </summary>
    public string Description { get; set; } = "";

    /// <summary>
    ///     Gets or sets the number of stars the repository has.
    /// </summary>
    public int Stars { get; set; }

    /// <summary>
    ///     Gets or sets the number of forks the repository has.
    /// </summary>
    public int Forks { get; set; }
}