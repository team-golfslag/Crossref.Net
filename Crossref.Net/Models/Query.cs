using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class Query
{
    [JsonPropertyName("start-index")]
    public int StartIndex { get; set; }

    [JsonPropertyName("search-terms")]
    public required object SearchTerms { get; set; }
}
