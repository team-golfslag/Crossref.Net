using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class MultipleWorksMessage
{
    [JsonPropertyName("facets")]
    public Facets? Facets { get; set; }

    [JsonPropertyName("total-results")]
    public int TotalResults { get; set; }

    [JsonPropertyName("items")]
    public required List<Work> Items { get; set; }

    [JsonPropertyName("items-per-page")]
    public int ItemsPerPage { get; set; }

    [JsonPropertyName("query")]
    public Query? Query { get; set; }
}
