using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class JournalIssue
{
    [JsonPropertyName("issue")]
    public required string Issue { get; set; }

    [JsonPropertyName("published-print")]
    public PublishedPrint? PublishedPrint { get; set; }

    [JsonPropertyName("published-online")]
    public PublishedOnline? PublishedOnline { get; set; }
}
