// This program has been developed by students from the bachelor Computer Science at Utrecht
// University within the Software Project course.
// 
// © Copyright Utrecht University (Department of Information and Computing Sciences)

using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class Author
{
    [JsonPropertyName("given")]
    public string? Given { get; set; }

    [JsonPropertyName("family")]
    public required string Family { get; set; }

    [JsonPropertyName("sequence")]
    public required string Sequence { get; set; }

    [JsonPropertyName("affiliation")]
    public required List<AuthorAffiliation> Affiliation { get; set; }
}
