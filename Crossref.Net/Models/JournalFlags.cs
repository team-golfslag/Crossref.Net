// This program has been developed by students from the bachelor Computer Science at Utrecht
// University within the Software Project course.
// 
// © Copyright Utrecht University (Department of Information and Computing Sciences)

using System.Text.Json.Serialization;

namespace Crossref.Net.Models;

public class JournalFlags
{
    [JsonPropertyName("deposits-abstracts-current")]
    public bool DepositsAbstractsCurrent { get; set; }

    [JsonPropertyName("deposits-orcids-current")]
    public bool DepositsOrcidsCurrent { get; set; }

    [JsonPropertyName("deposits")]
    public bool Deposits { get; set; }

    [JsonPropertyName("deposits-affiliations-backfile")]
    public bool DepositsAffiliationsBackfile { get; set; }

    [JsonPropertyName("deposits-update-policies-backfile")]
    public bool DepositsUpdatePoliciesBackfile { get; set; }

    [JsonPropertyName("deposits-similarity-checking-backfile")]
    public bool DepositsSimilarityCheckingBackfile { get; set; }

    [JsonPropertyName("deposits-award-numbers-current")]
    public bool DepositsAwardNumbersCurrent { get; set; }

    [JsonPropertyName("deposits-resource-links-current")]
    public bool DepositsResourceLinksCurrent { get; set; }

    [JsonPropertyName("deposits-ror-ids-current")]
    public bool DepositsRorIdsCurrent { get; set; }

    [JsonPropertyName("deposits-articles")]
    public bool DepositsArticles { get; set; }

    [JsonPropertyName("deposits-affiliations-current")]
    public bool DepositsAffiliationsCurrent { get; set; }

    [JsonPropertyName("deposits-funders-current")]
    public bool DepositsFundersCurrent { get; set; }

    [JsonPropertyName("deposits-references-backfile")]
    public bool DepositsReferencesBackfile { get; set; }

    [JsonPropertyName("deposits-ror-ids-backfile")]
    public bool DepositsRorIdsBackfile { get; set; }

    [JsonPropertyName("deposits-abstracts-backfile")]
    public bool DepositsAbstractsBackfile { get; set; }

    [JsonPropertyName("deposits-licenses-backfile")]
    public bool DepositsLicensesBackfile { get; set; }

    [JsonPropertyName("deposits-award-numbers-backfile")]
    public bool DepositsAwardNumbersBackfile { get; set; }

    [JsonPropertyName("deposits-descriptions-current")]
    public bool DepositsDescriptionsCurrent { get; set; }

    [JsonPropertyName("deposits-references-current")]
    public bool DepositsReferencesCurrent { get; set; }

    [JsonPropertyName("deposits-resource-links-backfile")]
    public bool DepositsResourceLinksBackfile { get; set; }

    [JsonPropertyName("deposits-descriptions-backfile")]
    public bool DepositsDescriptionsBackfile { get; set; }

    [JsonPropertyName("deposits-orcids-backfile")]
    public bool DepositsOrcidsBackfile { get; set; }

    [JsonPropertyName("deposits-funders-backfile")]
    public bool DepositsFundersBackfile { get; set; }

    [JsonPropertyName("deposits-update-policies-current")]
    public bool DepositsUpdatePoliciesCurrent { get; set; }

    [JsonPropertyName("deposits-similarity-checking-current")]
    public bool DepositsSimilarityCheckingCurrent { get; set; }

    [JsonPropertyName("deposits-licenses-current")]
    public bool DepositsLicensesCurrent { get; set; }
}
