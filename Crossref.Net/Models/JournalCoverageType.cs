// This program has been developed by students from the bachelor Computer Science at Utrecht
// University within the Software Project course.
// 
// © Copyright Utrecht University (Department of Information and Computing Sciences)

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
