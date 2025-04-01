// This program has been developed by students from the bachelor Computer Science at Utrecht
// University within the Software Project course.
// 
// © Copyright Utrecht University (Department of Information and Computing Sciences)

using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class CombinedJournalCoverage
{
    [JsonPropertyName("affiliations-current")]
    public double AffiliationsCurrent { get; set; }

    [JsonPropertyName("similarity-checking-current")]
    public double SimilarityCheckingCurrent { get; set; }

    [JsonPropertyName("descriptions-current")]
    public double DescriptionsCurrent { get; set; }

    [JsonPropertyName("ror-ids-current")]
    public double RorIdsCurrent { get; set; }

    [JsonPropertyName("funders-backfile")]
    public double FundersBackfile { get; set; }

    [JsonPropertyName("licenses-backfile")]
    public double LicensesBackfile { get; set; }

    [JsonPropertyName("funders-current")]
    public double FundersCurrent { get; set; }

    [JsonPropertyName("affiliations-backfile")]
    public double AffiliationsBackfile { get; set; }

    [JsonPropertyName("resource-links-backfile")]
    public double ResourceLinksBackfile { get; set; }

    [JsonPropertyName("orcids-backfile")]
    public double OrcidsBackfile { get; set; }

    [JsonPropertyName("update-policies-current")]
    public double UpdatePoliciesCurrent { get; set; }

    [JsonPropertyName("ror-ids-backfile")]
    public double RorIdsBackfile { get; set; }

    [JsonPropertyName("orcids-current")]
    public double OrcidsCurrent { get; set; }

    [JsonPropertyName("similarity-checking-backfile")]
    public double SimilarityCheckingBackfile { get; set; }

    [JsonPropertyName("references-backfile")]
    public double ReferencesBackfile { get; set; }

    [JsonPropertyName("descriptions-backfile")]
    public double DescriptionsBackfile { get; set; }

    [JsonPropertyName("award-numbers-backfile")]
    public double AwardNumbersBackfile { get; set; }

    [JsonPropertyName("update-policies-backfile")]
    public double UpdatePoliciesBackfile { get; set; }

    [JsonPropertyName("licenses-current")]
    public double LicensesCurrent { get; set; }

    [JsonPropertyName("award-numbers-current")]
    public double AwardNumbersCurrent { get; set; }

    [JsonPropertyName("abstracts-backfile")]
    public double AbstractsBackfile { get; set; }

    [JsonPropertyName("resource-links-current")]
    public double ResourceLinksCurrent { get; set; }

    [JsonPropertyName("abstracts-current")]
    public double AbstractsCurrent { get; set; }

    [JsonPropertyName("references-current")]
    public double ReferencesCurrent { get; set; }
}
