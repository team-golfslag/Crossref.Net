using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class JournalCoverageType
{
    [JsonPropertyName("all")]
    public JournalCoverage? All { get; set; }

    [JsonPropertyName("backfile")]
    public JournalCoverage? Backfile { get; set; }

    [JsonPropertyName("current")]
    public JournalCoverage? Current { get; set; }
}
