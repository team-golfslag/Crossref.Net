// This program has been developed by students from the bachelor Computer Science at Utrecht
// University within the Software Project course.
// 
// © Copyright Utrecht University (Department of Information and Computing Sciences)

using System.Net.Http.Json;
using System.Text.Json;
using Crossref.Net.Exceptions;
using Crossref.Net.Models;
using DoiTools.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Crossref.Net.Services;

/// <summary>
/// Service to interact with the Crossref API.
/// </summary>
public class CrossrefService : ICrossrefService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<CrossrefService> _logger;
    private readonly CrossrefServiceOptions _options;
    private DateTime _lastRequest = DateTime.MinValue;
    private int _rateLimitLimit;
    private int _rateLimitInterval;

    public CrossrefService(
        HttpClient httpClient,
        IOptions<CrossrefServiceOptions> options,
        ILogger<CrossrefService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        _options = options.Value;
        _httpClient.BaseAddress = new(_options.BaseUrl);
    }

    /// <inheritdoc />
    public async Task<Work?> GetWorkAsync(Doi doi)
    {
        string url = $"/works/{Uri.EscapeDataString(doi.ToString())}";
        HttpRequestMessage request = new(HttpMethod.Get, url);
        request.Headers.Add("User-Agent", _options.UserAgent);
        request.Headers.Add("mailto", _options.Mailto);

        if (_lastRequest != DateTime.MinValue)
            await DoDelay();

        HttpResponseMessage response = await _httpClient.SendAsync(request);
        ProcessResponse(response);

        try
        {
            WorkResponse? result = await response.Content.ReadFromJsonAsync<WorkResponse>(_options.JsonSerializerOptions);
            return result?.Work;
        }
        catch (JsonException je)
        {
            _logger.LogError(je, "Failed to deserialize WorkResponse for DOI {Doi}", doi);
            throw new CrossrefException(
                "Failed to deserialize WorkResponse", je);
        }
    }

    /// <inheritdoc />
    public async Task<List<Work>> GetWorksAsync(string query, int limit = 20)
    {
        string url = $"/works?query={Uri.EscapeDataString(query)}&rows={limit}";
        HttpRequestMessage request = new(HttpMethod.Get, url);
        request.Headers.Add("User-Agent", _options.UserAgent);
        request.Headers.Add("mailto", _options.Mailto);

        if (_lastRequest != DateTime.MinValue)
            await DoDelay();

        HttpResponseMessage response = await _httpClient.SendAsync(request);
        ProcessResponse(response);

        try
        {
            MultipleWorksResponse? result = await response.Content.ReadFromJsonAsync<MultipleWorksResponse>(_options.JsonSerializerOptions);
            return result?.Message.Items ?? [];
        }
        catch (JsonException je)
        {
            _logger.LogError(je, "Failed to deserialize MultipleWorksResponse for query {Query}", query);
            throw new CrossrefException(
                "Failed to deserialize MultipleWorksResponse", je);
        }
    }

    /// <inheritdoc />
    public async Task<Journal?> GetJournalAsync(string issn)
    {
        string url = $"/journals/{Uri.EscapeDataString(issn)}";
        HttpRequestMessage request = new(HttpMethod.Get, url);
        request.Headers.Add("User-Agent", _options.UserAgent);
        request.Headers.Add("mailto", _options.Mailto);

        if (_lastRequest != DateTime.MinValue)
            await DoDelay();

        HttpResponseMessage response = await _httpClient.SendAsync(request);
        ProcessResponse(response);

        try
        {
            JournalResponse? result = await response.Content.ReadFromJsonAsync<JournalResponse>(_options.JsonSerializerOptions);
            return result?.Journal;
        }
        catch (JsonException je)
        {
            _logger.LogError(je, "Failed to deserialize JournalResponse for ISSN {Issn}", issn);
            throw new CrossrefException(
                "Failed to deserialize JournalResponse", je);
        }
    }

    /// <inheritdoc />
    public async Task<List<Journal>> GetJournalsAsync(string query, int limit = 20)
    {
        string url = $"/journals?query={Uri.EscapeDataString(query)}&rows={limit}";
        HttpRequestMessage request = new(HttpMethod.Get, url);
        request.Headers.Add("User-Agent", _options.UserAgent);
        request.Headers.Add("mailto", _options.Mailto);

        if (_lastRequest != DateTime.MinValue)
            await DoDelay();

        HttpResponseMessage response = await _httpClient.SendAsync(request);
        ProcessResponse(response);

        try
        {
            MultipleJournalsResponse? result = await response.Content.ReadFromJsonAsync<MultipleJournalsResponse>(_options.JsonSerializerOptions);
            return result?.Message.Items ?? [];
        }
        catch (JsonException je)
        {
            _logger.LogError(je, "Failed to deserialize MultipleJournalsResponse for query {Query}", query);
            throw new CrossrefException(
                "Failed to deserialize MultipleJournalsResponse", je);
        }
    }

    private void ProcessResponse(HttpResponseMessage response)
    {
        if (response.Headers.TryGetValues("X-Rate-Limit-Limit", out var lim))
            int.TryParse(lim.FirstOrDefault(), out _rateLimitLimit);
        _rateLimitLimit = _rateLimitLimit == 0 ? 1 : _rateLimitLimit;

        if (response.Headers.TryGetValues("X-Rate-Limit-Interval", out var intv))
            int.TryParse(intv.FirstOrDefault()?.TrimEnd('s'), out _rateLimitInterval);
        _rateLimitInterval = _rateLimitInterval == 0 ? 1 : _rateLimitInterval;

        _lastRequest = DateTime.UtcNow;
    }

    private Task DoDelay()
    {
        double delayMs = (double)_rateLimitInterval / _rateLimitLimit * 1000;
        return Task.Delay((int)Math.Ceiling(delayMs));
    }
}