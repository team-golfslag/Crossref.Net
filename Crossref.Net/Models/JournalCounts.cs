using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class JournalCounts
{
    [JsonPropertyName("current-dois")]
    public int CurrentDois { get; set; }

    [JsonPropertyName("backfile-dois")]
    public int BackfileDois { get; set; }

    [JsonPropertyName("total-dois")]
    public int TotalDois { get; set; }
}
