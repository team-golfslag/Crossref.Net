using System.Net.Http.Json;
using System.Text.Json;
using System.Web;
using Crossref.Net.Models;
using DoiTools.Net;
using Microsoft.Extensions.Logging;

namespace Crossref.Net.Services;

/// <summary>
/// Service to interact with the Crossref API.
/// </summary>
public sealed class CrossrefService(
    HttpClient httpClient,
    ILogger<CrossrefService> logger,
    CrossrefServiceOptions? options = null) : IDisposable
{
    private readonly CrossrefServiceOptions _options = options ?? new CrossrefServiceOptions();
    private DateTime _lastRequest = DateTime.MinValue;
    private int _rateLimitInterval;

    private int _rateLimitLimit;

    public void Dispose() => httpClient?.Dispose();

    public async Task<Work?> GetWork(Doi doi)
    {
        try
        {
            HttpRequestMessage request = new(HttpMethod.Get,
                $"{_options.BaseUrl}/works/{HttpUtility.UrlEncode(doi.ToString())}");
            request.Headers.Add("User-Agent", _options.UserAgent);
            request.Headers.Add("mailto", _options.Mailto);

            if (_lastRequest != DateTime.MinValue)
                await DoDelay();

            HttpResponseMessage response = await httpClient.SendAsync(request);
            ProcessResponse(response);

            WorkResponse? result =
                await response.Content.ReadFromJsonAsync<WorkResponse>(_options.JsonSerializerOptions);
            return result?.Work;
        }
        catch (HttpRequestException e)
        {
            throw new HttpRequestException("Failed to send the request to the Crossref API.", e);
        }
        catch (JsonException e)
        {
            throw new JsonException("Failed to parse the response from the Crossref API.", e);
        }
    }

    public async Task<List<Work>> GetWorks(string query, int limit = 20)
    {
        try
        {
            HttpRequestMessage request = new(HttpMethod.Get,
                $"{_options.BaseUrl}/works?query={HttpUtility.UrlEncode(query)}&rows={limit}");
            request.Headers.Add("User-Agent", _options.UserAgent);
            request.Headers.Add("mailto", _options.Mailto);

            if (_lastRequest != DateTime.MinValue)
                await DoDelay();

            HttpResponseMessage response = await httpClient.SendAsync(request);
            ProcessResponse(response);

            MultipleWorksResponse? result =
                await response.Content.ReadFromJsonAsync<MultipleWorksResponse>(_options.JsonSerializerOptions);
            return result?.Message.Items ?? [];
        }
        catch (HttpRequestException e)
        {
            throw new HttpRequestException("Failed to send the request to the Crossref API.", e);
        }
        catch (JsonException e)
        {
            throw new JsonException("Failed to parse the response from the Crossref API.", e);
        }
    }

    public async Task<Journal?> GetJournal(string issn)
    {
        try
        {
            HttpRequestMessage request = new(HttpMethod.Get,
                $"{_options.BaseUrl}/journals/{HttpUtility.UrlEncode(issn)}");
            request.Headers.Add("User-Agent", _options.UserAgent);
            request.Headers.Add("mailto", _options.Mailto);

            if (_lastRequest != DateTime.MinValue)
                await DoDelay();

            HttpResponseMessage response = await httpClient.SendAsync(request);
            ProcessResponse(response);

            JournalResponse? result =
                await response.Content.ReadFromJsonAsync<JournalResponse>(_options.JsonSerializerOptions);
            return result?.Journal;
        }
        catch (HttpRequestException e)
        {
            throw new HttpRequestException("Failed to send the request to the Crossref API.", e);
        }
        catch (JsonException e)
        {
            throw new JsonException("Failed to parse the response from the Crossref API.", e);
        }
    }

    public async Task<List<Journal>> GetJournals(string query, int limit = 20)
    {
        try
        {
            HttpRequestMessage request = new(HttpMethod.Get,
                $"{_options.BaseUrl}/journals?query={HttpUtility.UrlEncode(query)}&rows={limit}");
            request.Headers.Add("User-Agent", _options.UserAgent);
            request.Headers.Add("mailto", _options.Mailto);

            if (_lastRequest != DateTime.MinValue)
                await DoDelay();

            HttpResponseMessage response = await httpClient.SendAsync(request);
            ProcessResponse(response);

            MultipleJournalsResponse? result =
                await response.Content.ReadFromJsonAsync<MultipleJournalsResponse>(_options.JsonSerializerOptions);
            return result?.Message.Items ?? [];
        }
        catch (HttpRequestException e)
        {
            throw new HttpRequestException("Failed to send the request to the Crossref API.", e);
        }
        catch (JsonException e)
        {
            throw new JsonException("Failed to parse the response from the Crossref API.", e);
        }
    }

    private void ProcessResponse(HttpResponseMessage response)
    {
        if (response.Headers.TryGetValues("X-Rate-Limit-Limit", out var values))
        {
            if (int.TryParse(values.First(), out int limit))
                _rateLimitLimit = limit;
        }
        else if (_rateLimitLimit == 0)
        {
            _rateLimitLimit = 1;
        }

        if (response.Headers.TryGetValues("X-Rate-Limit-Interval", out values))
        {
            if (int.TryParse(values.First().TrimEnd('s'), out int interval))
                _rateLimitInterval = interval;
        }
        else if (_rateLimitInterval == 0)
        {
            _rateLimitInterval = 1;
        }

        _lastRequest = DateTime.Now;
    }

    private Task DoDelay()
    {
        TimeSpan delay = _rateLimitLimit == 0
            ? TimeSpan.Zero
            : TimeSpan.FromMilliseconds(Math.Ceiling((double)_rateLimitInterval / _rateLimitLimit));

        return Task.Delay(delay);
    }
}
