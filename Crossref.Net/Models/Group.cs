// This program has been developed by students from the bachelor Computer Science at Utrecht
// University within the Software Project course.
// 
// © Copyright Utrecht University (Department of Information and Computing Sciences)

using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class Group
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("label")]
    public required string Label { get; set; }
}
