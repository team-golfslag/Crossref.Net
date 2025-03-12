using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class ContentDomain
{
    [JsonPropertyName("domain")]
    public required List<string> Domain { get; set; }

    [JsonPropertyName("crossmark-restriction")]
    public bool CrossmarkRestriction { get; set; }
}
