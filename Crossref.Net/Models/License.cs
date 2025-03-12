using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class License
{
    [JsonPropertyName("start")]
    public required Start Start { get; set; }

    [JsonPropertyName("content-version")]
    public required string ContentVersion { get; set; }

    [JsonPropertyName("delay-in-days")]
    public int DelayInDays { get; set; }

    [JsonPropertyName("URL")]
    public required string URL { get; set; }
}
