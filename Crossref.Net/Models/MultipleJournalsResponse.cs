// This program has been developed by students from the bachelor Computer Science at Utrecht
// University within the Software Project course.
// 
// © Copyright Utrecht University (Department of Information and Computing Sciences)

using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class MultipleJournalsResponse
{
    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("message-type")]
    public required string MessageType { get; set; }

    [JsonPropertyName("message-version")]
    public required string MessageVersion { get; set; }

    [JsonPropertyName("message")]
    public required MultipleJournalMessage Message { get; set; }
}
