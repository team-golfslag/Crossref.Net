// This program has been developed by students from the bachelor Computer Science at Utrecht
// University within the Software Project course.
// 
// © Copyright Utrecht University (Department of Information and Computing Sciences)

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
