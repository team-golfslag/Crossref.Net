using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class JournalResponse
{
    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("message-type")]
    public required string MessageType { get; set; }

    [JsonPropertyName("message-version")]
    public required string MessageVersion { get; set; }

    [JsonPropertyName("message")]
    public required Journal Journal { get; set; }
}
