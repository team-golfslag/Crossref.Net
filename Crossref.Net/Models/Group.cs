using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class Group
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("label")]
    public required string Label { get; set; }
}
