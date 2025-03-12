using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class Published
{
    [JsonPropertyName("date-parts")]
    public required List<List<int?>> DateParts { get; set; }
}
