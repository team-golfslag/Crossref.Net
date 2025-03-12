using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class Journal
{
    [JsonPropertyName("last-status-check-time")]
    public ulong LastStatusCheckTime { get; set; }

    [JsonPropertyName("counts")]
    public required JournalCounts Counts { get; set; }

    [JsonPropertyName("breakdowns")]
    public required JournalBreakdowns Breakdowns { get; set; }

    [JsonPropertyName("publisher")]
    public required string Publisher { get; set; }

    [JsonPropertyName("coverage")]
    public required CombinedJournalCoverage Coverage { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("subjects")]
    public required List<object> Subjects { get; set; }

    [JsonPropertyName("coverage-type")]
    public required JournalCoverageType CoverageType { get; set; }

    [JsonPropertyName("flags")]
    public required JournalFlags Flags { get; set; }

    [JsonPropertyName("ISSN")]
    public required List<string> ISSN { get; set; }

    [JsonPropertyName("issn-type")]
    public required List<IssnType> IssnType { get; set; }
}
