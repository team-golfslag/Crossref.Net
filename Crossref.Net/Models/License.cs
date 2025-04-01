// This program has been developed by students from the bachelor Computer Science at Utrecht
// University within the Software Project course.
// 
// © Copyright Utrecht University (Department of Information and Computing Sciences)

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
