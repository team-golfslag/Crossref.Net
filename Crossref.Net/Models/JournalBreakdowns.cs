using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class JournalBreakdowns
{
    [JsonPropertyName("dois-by-issued-year")]
    public required List<List<int>> DoisByIssuedYear { get; set; }
}
