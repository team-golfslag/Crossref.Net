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
