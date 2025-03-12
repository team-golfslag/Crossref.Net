using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class Primary
{
    [JsonPropertyName("URL")]
    public required string URL { get; set; }
}
