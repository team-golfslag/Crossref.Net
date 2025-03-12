using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class IssnType
{
    [JsonPropertyName("value")]
    public required string Value { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }
}
