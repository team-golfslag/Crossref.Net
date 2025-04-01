// This program has been developed by students from the bachelor Computer Science at Utrecht
// University within the Software Project course.
// 
// © Copyright Utrecht University (Department of Information and Computing Sciences)

using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class JournalBreakdowns
{
    [JsonPropertyName("dois-by-issued-year")]
    public required List<List<int>> DoisByIssuedYear { get; set; }
}
