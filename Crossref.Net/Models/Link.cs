using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class Link
{
    [JsonPropertyName("URL")]
    public required string URL { get; set; }

    [JsonPropertyName("content-type")]
    public required string ContentType { get; set; }

    [JsonPropertyName("content-version")]
    public required string ContentVersion { get; set; }

    [JsonPropertyName("intended-application")]
    public required string IntendedApplication { get; set; }
}
