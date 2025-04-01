// This program has been developed by students from the bachelor Computer Science at Utrecht
// University within the Software Project course.
// 
// © Copyright Utrecht University (Department of Information and Computing Sciences)

using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class MultipleJournalMessage
{
    [JsonPropertyName("items-per-page")]
    public int ItemsPerPage { get; set; }

    [JsonPropertyName("query")]
    public required Query Query { get; set; }

    [JsonPropertyName("total-results")]
    public int TotalResults { get; set; }

    [JsonPropertyName("items")]
    public required List<Journal> Items { get; set; }
}
