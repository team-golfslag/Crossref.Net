using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class WorkResource
{
    [JsonPropertyName("primary")]
    public required Primary Primary { get; set; }
}
