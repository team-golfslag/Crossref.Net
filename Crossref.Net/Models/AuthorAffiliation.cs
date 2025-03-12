using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class AuthorAffiliation
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }
}
