using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class Assertion
{
    [JsonPropertyName("value")]
    public required string Value { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("label")]
    public required string Label { get; set; }

    [JsonPropertyName("group")]
    public required Group Group { get; set; }
}
