using System.Text.Json.Serialization;
using DoiTools.Net;

namespace Crossref.Net.Models;

public class Reference
{
    [JsonPropertyName("key")]
    public string? Key { get; set; }

    [JsonPropertyName("first-page")]
    public string? FirstPage { get; set; }

    [JsonPropertyName("volume")]
    public string? Volume { get; set; }

    [JsonPropertyName("author")]
    public string? Author { get; set; }

    [JsonPropertyName("year")]
    public string? Year { get; set; }

    [JsonPropertyName("journal-title")]
    public string? JournalTitle { get; set; }

    [JsonPropertyName("doi-asserted-by")]
    public string? DoiAssertedBy { get; set; }

    [JsonPropertyName("DOI")]
    public Doi? Doi { get; set; }

    [JsonPropertyName("series-title")]
    public string? SeriesTitle { get; set; }

    [JsonPropertyName("unstructured")]
    public string? Unstructured { get; set; }

    [JsonPropertyName("volume-title")]
    public string? VolumeTitle { get; set; }

    [JsonPropertyName("article-title")]
    public string? ArticleTitle { get; set; }

    [JsonPropertyName("issue")]
    public string? Issue { get; set; }
}