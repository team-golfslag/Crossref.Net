using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class Start
{
    [JsonPropertyName("date-parts")]
    public required List<List<int?>> DateParts { get; set; }

    [JsonPropertyName("date-time")]
    public DateTime DateTime { get; set; }

    [JsonPropertyName("timestamp")]
    public required long Timestamp { get; set; }
}
