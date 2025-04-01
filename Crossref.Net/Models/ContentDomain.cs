// This program has been developed by students from the bachelor Computer Science at Utrecht
// University within the Software Project course.
// 
// © Copyright Utrecht University (Department of Information and Computing Sciences)

using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class ContentDomain
{
    [JsonPropertyName("domain")]
    public required List<string> Domain { get; set; }

    [JsonPropertyName("crossmark-restriction")]
    public bool CrossmarkRestriction { get; set; }
}
