// This program has been developed by students from the bachelor Computer Science at Utrecht
// University within the Software Project course.
// 
// © Copyright Utrecht University (Department of Information and Computing Sciences)

using Crossref.Net.Models;
using DoiTools.Net;

namespace Crossref.Net.Services;

/// <summary>
/// Service to interact with the Crossref API.
/// </summary>
public interface ICrossrefService
{
    /// <summary>
    /// GET /works/{doi}
    /// Retrieves a single work by DOI.
    /// </summary>
    Task<Work?> GetWorkAsync(Doi doi);

    /// <summary>
    /// GET /works?query={query}&rows={limit}
    /// Searches works matching the query.
    /// </summary>
    Task<List<Work>> GetWorksAsync(string query, int limit = 20);

    /// <summary>
    /// GET /journals/{issn}
    /// Retrieves a single journal by ISSN.
    /// </summary>
    Task<Journal?> GetJournalAsync(string issn);

    /// <summary>
    /// GET /journals?query={query}&rows={limit}
    /// Searches journals matching the query.
    /// </summary>
    Task<List<Journal>> GetJournalsAsync(string query, int limit = 20);
}