// This program has been developed by students from the bachelor Computer Science at Utrecht
// University within the Software Project course.
// 
// © Copyright Utrecht University (Department of Information and Computing Sciences)

using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class JournalCoverage
{
    [JsonPropertyName("last-status-check-time")]
    public ulong LastStatusCheckTime { get; set; }

    [JsonPropertyName("affiliations")]
    public double Affiliations { get; set; }

    [JsonPropertyName("abstracts")]
    public double Abstracts { get; set; }

    [JsonPropertyName("orcids")]
    public double Orcids { get; set; }

    [JsonPropertyName("licenses")]
    public double Licenses { get; set; }

    [JsonPropertyName("references")]
    public double References { get; set; }

    [JsonPropertyName("funders")]
    public double Funders { get; set; }

    [JsonPropertyName("similarity-checking")]
    public double SimilarityChecking { get; set; }

    [JsonPropertyName("award-numbers")]
    public double AwardNumbers { get; set; }

    [JsonPropertyName("ror-ids")]
    public double RorIds { get; set; }

    [JsonPropertyName("update-policies")]
    public double UpdatePolicies { get; set; }

    [JsonPropertyName("resource-links")]
    public double ResourceLinks { get; set; }

    [JsonPropertyName("descriptions")]
    public double Descriptions { get; set; }
}
