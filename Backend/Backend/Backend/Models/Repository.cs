namespace Backend.Models;

/// <summary>Represents a GitHub repository.</summary>
public sealed class Repository
{
    /// <summary>Gets or sets the name of the repository.</summary>
    public string Name { get; set; } = "";

    /// <summary>Gets or sets the description of the repository.</summary>
    public string Description { get; set; } = "";

    /// <summary>Gets or sets the number of stars the repository has.</summary>
    public int Stars { get; set; }

    /// <summary>Gets or sets the number of forks the repository has.</summary>
    public int Forks { get; set; }

    /// <summary>Gets or sets the primary programming language of the repository.</summary>
    public string? PrimaryLanguage { get; set; }

    /// <summary>Gets or sets the last update time of the repository in UTC.</summary>
    public DateTime LastUpdateUtc { get; set; }

    /// <summary>Gets or sets the number of open issues in the repository.</summary>
    public int OpenIssues { get; set; }

    /// <summary>
    ///     This repository scoring algorithm combines popularity, activity, and health into a single value.
    ///     - Popularity is measured by stars and forks with logarithmic scaling
    ///     - Freshness is calculated from the last update date using a reciprocal log decay, rewarding recent activity.
    ///     - Health is measured by the number of open issues, with more issues lowering the score.
    /// </summary>
    public double CalculateScore()
    {
        const double starsWeight = 3.0;
        const double forksWeight = 2.0;
        const double freshnessWeight = 2.5;
        const double healthWeight = 1.5;

        var daysSinceUpdate = (DateTime.UtcNow - LastUpdateUtc).TotalDays;

        // Apply the formula
        var score =
            starsWeight * Math.Log(1 + Stars) +
            forksWeight * Math.Log(1 + Forks) +
            freshnessWeight * (1.0 / (1.0 + Math.Log(1 + daysSinceUpdate))) +
            healthWeight * (1.0 / (1.0 + Math.Log(1 + OpenIssues)));

        return Math.Round(score, 2);
    }
}