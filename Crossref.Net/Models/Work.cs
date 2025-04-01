// This program has been developed by students from the bachelor Computer Science at Utrecht
// University within the Software Project course.
// 
// © Copyright Utrecht University (Department of Information and Computing Sciences)

using System.Text.Json.Serialization;
using DoiTools.Net;

namespace Crossref.Net.Models;

public class Work
{
    [JsonPropertyName("indexed")]
    public Indexed Indexed { get; set; }

    [JsonPropertyName("reference-count")]
    public int ReferenceCount { get; set; }

    [JsonPropertyName("publisher")]
    public string? Publisher { get; set; }

    [JsonPropertyName("issue")]
    public string? Issue { get; set; }

    [JsonPropertyName("license")]
    public List<License>? License { get; set; }

    [JsonPropertyName("content-domain")]
    public ContentDomain ContentDomain { get; set; }

    [JsonPropertyName("short-container-title")]
    public List<string> ShortContainerTitle { get; set; }

    [JsonPropertyName("published-print")]
    public PublishedPrint? PublishedPrint { get; set; }

    [JsonPropertyName("DOI")]
    public Doi? Doi { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("created")]
    public Created? Created { get; set; }

    [JsonPropertyName("page")]
    public string? Page { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("is-referenced-by-count")]
    public int IsReferencedByCount { get; set; }

    [JsonPropertyName("title")]
    public List<string>? Title { get; set; }

    [JsonPropertyName("prefix")]
    public string? Prefix { get; set; }

    [JsonPropertyName("volume")]
    public string? Volume { get; set; }

    [JsonPropertyName("author")]
    public List<Author>? Author { get; set; }

    [JsonPropertyName("member")]
    public string? Member { get; set; }

    [JsonPropertyName("reference")]
    public List<Reference>? Reference { get; set; }

    [JsonPropertyName("container-title")]
    public List<string>? ContainerTitle { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("link")]
    public List<Link>? Link { get; set; }

    [JsonPropertyName("deposited")]
    public Deposited? Deposited { get; set; }

    [JsonPropertyName("score")]
    public double Score { get; set; }

    [JsonPropertyName("resource")]
    public WorkResource? WorkResource { get; set; }

    [JsonPropertyName("issued")]
    public Issued? Issued { get; set; }

    [JsonPropertyName("references-count")]
    public int ReferencesCount { get; set; }

    [JsonPropertyName("journal-issue")]
    public JournalIssue? JournalIssue { get; set; }

    [JsonPropertyName("alternative-id")]
    public List<string>? AlternativeId { get; set; }

    [JsonPropertyName("URL")]
    public string? Url { get; set; }

    [JsonPropertyName("ISSN")]
    public List<string>? Issn { get; set; }

    [JsonPropertyName("issn-type")]
    public List<IssnType>? IssnType { get; set; }

    [JsonPropertyName("published")]
    public Published? Published { get; set; }

    [JsonPropertyName("published-online")]
    public PublishedOnline? PublishedOnline { get; set; }

    [JsonPropertyName("abstract")]
    public string? Abstract { get; set; }

    [JsonPropertyName("subtitle")]
    public List<string>? Subtitle { get; set; }

    [JsonPropertyName("archive")]
    public List<string>? Archive { get; set; }

    [JsonPropertyName("update-policy")]
    public string? UpdatePolicy { get; set; }

    [JsonPropertyName("assertion")]
    public List<Assertion>? Assertion { get; set; }
}
