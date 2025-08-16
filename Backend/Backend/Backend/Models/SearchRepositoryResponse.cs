using System.Text.Json.Serialization;

namespace Backend.Models;

public sealed class SearchRepositoryResponse
{
    [JsonPropertyName("total_count")] public int TotalCount { get; set; }

    [JsonPropertyName("incomplete_results")]
    public bool IncompleteResults { get; set; }

    [JsonPropertyName("items")] public List<RepositoryItem> Items { get; set; }
}

public sealed class RepositoryItem
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("node_id")] public string NodeId { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("full_name")] public string FullName { get; set; }

    [JsonPropertyName("private")] public bool Private { get; set; }

    [JsonPropertyName("owner")] public Owner Owner { get; set; }

    [JsonPropertyName("html_url")] public string HtmlUrl { get; set; }

    [JsonPropertyName("description")] public string Description { get; set; }

    [JsonPropertyName("fork")] public bool Fork { get; set; }

    [JsonPropertyName("url")] public string Url { get; set; }

    [JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")] public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("pushed_at")] public DateTime PushedAt { get; set; }

    [JsonPropertyName("git_url")] public string GitUrl { get; set; }

    [JsonPropertyName("ssh_url")] public string SshUrl { get; set; }

    [JsonPropertyName("clone_url")] public string CloneUrl { get; set; }

    [JsonPropertyName("svn_url")] public string SvnUrl { get; set; }

    [JsonPropertyName("homepage")] public string Homepage { get; set; }

    [JsonPropertyName("size")] public int Size { get; set; }

    [JsonPropertyName("stargazers_count")] public int StargazersCount { get; set; }

    [JsonPropertyName("watchers_count")] public int WatchersCount { get; set; }

    [JsonPropertyName("language")] public string Language { get; set; }

    [JsonPropertyName("has_issues")] public bool HasIssues { get; set; }

    [JsonPropertyName("has_projects")] public bool HasProjects { get; set; }

    [JsonPropertyName("has_downloads")] public bool HasDownloads { get; set; }

    [JsonPropertyName("has_wiki")] public bool HasWiki { get; set; }

    [JsonPropertyName("has_pages")] public bool HasPages { get; set; }

    [JsonPropertyName("has_discussions")] public bool HasDiscussions { get; set; }

    [JsonPropertyName("forks_count")] public int ForksCount { get; set; }

    [JsonPropertyName("mirror_url")] public string MirrorUrl { get; set; }

    [JsonPropertyName("archived")] public bool Archived { get; set; }

    [JsonPropertyName("disabled")] public bool Disabled { get; set; }

    [JsonPropertyName("open_issues_count")]
    public int OpenIssuesCount { get; set; }

    [JsonPropertyName("license")] public License License { get; set; }

    [JsonPropertyName("allow_forking")] public bool AllowForking { get; set; }

    [JsonPropertyName("is_template")] public bool IsTemplate { get; set; }

    [JsonPropertyName("web_commit_signoff_required")]
    public bool WebCommitSignoffRequired { get; set; }

    [JsonPropertyName("topics")] public List<string> Topics { get; set; }

    [JsonPropertyName("visibility")] public string Visibility { get; set; }

    [JsonPropertyName("forks")] public int Forks { get; set; }

    [JsonPropertyName("open_issues")] public int OpenIssues { get; set; }

    [JsonPropertyName("watchers")] public int Watchers { get; set; }

    [JsonPropertyName("default_branch")] public string DefaultBranch { get; set; }

    [JsonPropertyName("score")] public double Score { get; set; }
}

public sealed class Owner
{
    [JsonPropertyName("login")] public string Login { get; set; }

    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("node_id")] public string NodeId { get; set; }

    [JsonPropertyName("avatar_url")] public string AvatarUrl { get; set; }

    [JsonPropertyName("gravatar_id")] public string GravatarId { get; set; }

    [JsonPropertyName("url")] public string Url { get; set; }

    [JsonPropertyName("html_url")] public string HtmlUrl { get; set; }

    [JsonPropertyName("followers_url")] public string FollowersUrl { get; set; }

    [JsonPropertyName("following_url")] public string FollowingUrl { get; set; }

    [JsonPropertyName("gists_url")] public string GistsUrl { get; set; }

    [JsonPropertyName("starred_url")] public string StarredUrl { get; set; }

    [JsonPropertyName("subscriptions_url")]
    public string SubscriptionsUrl { get; set; }

    [JsonPropertyName("organizations_url")]
    public string OrganizationsUrl { get; set; }

    [JsonPropertyName("repos_url")] public string ReposUrl { get; set; }

    [JsonPropertyName("events_url")] public string EventsUrl { get; set; }

    [JsonPropertyName("received_events_url")]
    public string ReceivedEventsUrl { get; set; }

    [JsonPropertyName("type")] public string Type { get; set; }

    [JsonPropertyName("user_view_type")] public string UserViewType { get; set; }

    [JsonPropertyName("site_admin")] public bool SiteAdmin { get; set; }
}

public sealed class License
{
    [JsonPropertyName("key")] public string Key { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("spdx_id")] public string SpdxId { get; set; }

    [JsonPropertyName("url")] public string Url { get; set; }

    [JsonPropertyName("node_id")] public string NodeId { get; set; }
}