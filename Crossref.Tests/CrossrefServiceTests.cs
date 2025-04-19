// This program has been developed by students from the bachelor Computer Science at Utrecht
// University within the Software Project course.
// 
// © Copyright Utrecht University (Department of Information and Computing Sciences)

using System.Net;
using System.Net.Http.Json;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Crossref.Net.Exceptions;
using Crossref.Net.Models;
using Crossref.Net.Services;
using DoiTools.Net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;

namespace Crossref.Tests;

public class CrossrefServiceTests
{
    private readonly CrossrefService _crossrefService;
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;

    public CrossrefServiceTests()
    {
        _httpMessageHandlerMock = new();
        Mock<IOptions<CrossrefServiceOptions>> optionsMock = new();
        optionsMock.Setup(o => o.Value).Returns(new CrossrefServiceOptions
        {
            BaseUrl = "https://api.crossref.org",
            Mailto = "mailto:crossref@crossref.net",
            UserAgent = "Crossref.Net",
            JsonSerializerOptions = new()
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower), new DoiConverter() },
            },
        });

        HttpClient httpClient = new(_httpMessageHandlerMock.Object)
        {
            BaseAddress = new("https://api.crossref.org")
        };
        Mock<ILogger<CrossrefService>> loggerMock = new();
        _crossrefService = new(
            httpClient,
            optionsMock.Object,
            loggerMock.Object
        );
    }

    [Fact]
    public async Task GetWork_ShouldReturnWork_WhenResponseIsValid()
    {
        // Arrange
        Doi doi = Doi.Parse("10.1000/xyz123");
        Work work = new()
        {
            Doi = Doi.Parse("10.1000/xyz123"),
            Title = ["Test Work"],
        };
        WorkResponse workResponse = new()
        {
            Work = work,
            Status = null,
            MessageType = null,
            MessageVersion = null,
        };
        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(workResponse, new("application/json"), new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                    Converters =
                    {
                        new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower),
                        new DoiConverter(),
                    },
                }),
            });

        // Act
        Work? result = await _crossrefService.GetWorkAsync(doi);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("10.1000/xyz123", result.Doi?.ToString());
        Assert.Equal("Test Work", result.Title?.FirstOrDefault());
    }

    [Fact]
    public async Task GetWork_ShouldThrowHttpRequestException_WhenRequestFails()
    {
        // Arrange
        Doi doi = Doi.Parse("10.1000/xyz123");
        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException("Request failed"));

        // Act
        await Assert.ThrowsAsync<HttpRequestException>(async () => await _crossrefService.GetWorkAsync(doi));
    }

    [Fact]
    public async Task GetWork_ShouldLogError_WhenJsonExceptionOccurs()
    {
        // Arrange
        Doi doi = Doi.Parse("10.1000/xyz123");
        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("Invalid JSON"),
            });

        // Act
        await Assert.ThrowsAsync<CrossrefException>(async () => await _crossrefService.GetWorkAsync(doi));
    }

    [Fact]
    public async Task GetWorks_ShouldReturnWorks_WhenResponseIsValid()
    {
        // Arrange
        string query = "test";
        var works = new List<Work>
        {
            new()
            {
                Doi = Doi.Parse("10.1000/xyz123"),
                Title = ["Test Work 1"],
            },
            new()
            {
                Doi = Doi.Parse("10.1000/xyz124"),
                Title = ["Test Work 2"],
            },
        };
        MultipleWorksResponse multipleWorksResponse = new()
        {
            Message = new()
            {
                Items = works,
            },
            Status = null,
            MessageType = null,
            MessageVersion = null,
        };
        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(multipleWorksResponse, new("application/json"), new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                    Converters =
                    {
                        new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower),
                        new DoiConverter(),
                    },
                }),
            });

        // Act
        var result = await _crossrefService.GetWorksAsync(query);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("10.1000/xyz123", result[0].Doi?.ToString());
        Assert.Equal("Test Work 1", result[0].Title?.FirstOrDefault());
        Assert.Equal("10.1000/xyz124", result[1].Doi?.ToString());
        Assert.Equal("Test Work 2", result[1].Title?.FirstOrDefault());
    }

    [Fact]
    public async Task GetJournal_ShouldReturnJournal_WhenResponseIsValid()
    {
        // Arrange
        const string issn = "1234-5678";
        Journal journal = new()
        {
            ISSN = ["1234-5678"],
            Title = "Test Journal",
            Counts = null,
            Breakdowns = null,
            Publisher = null,
            Coverage = null,
            Subjects = null,
            CoverageType = null,
            Flags = null,
            IssnType = null,
        };
        JournalResponse journalResponse = new()
        {
            Journal = journal,
            Status = null,
            MessageType = null,
            MessageVersion = null,
        };
        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(journalResponse),
            });

        // Act
        Journal? result = await _crossrefService.GetJournalAsync(issn);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("1234-5678", result.ISSN.FirstOrDefault());
        Assert.Equal("Test Journal", result.Title);
    }

    [Fact]
    public async Task GetJournals_ShouldReturnJournals_WhenResponseIsValid()
    {
        // Arrange
        const string query = "test";
        var journals = new List<Journal>
        {
            new()
            {
                ISSN = ["1234-5678"],
                Title = "Test Journal 1",
                Counts = null,
                Breakdowns = null,
                Publisher = null,
                Coverage = null,
                Subjects = null,
                CoverageType = null,
                Flags = null,
                IssnType = null,
            },
            new()
            {
                ISSN = ["1234-5679"],
                Title = "Test Journal 2",
                Counts = null,
                Breakdowns = null,
                Publisher = null,
                Coverage = null,
                Subjects = null,
                CoverageType = null,
                Flags = null,
                IssnType = null,
            },
        };
        MultipleJournalsResponse multipleJournalsResponse = new()
        {
            Message = new()
            {
                Items = journals,
                Query = null,
            },
            Status = null,
            MessageType = null,
            MessageVersion = null,
        };
        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(multipleJournalsResponse),
            });

        // Act
        var result = await _crossrefService.GetJournalsAsync(query);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("1234-5678", result[0].ISSN.FirstOrDefault());
        Assert.Equal("Test Journal 1", result[0].Title);
        Assert.Equal("1234-5679", result[1].ISSN.FirstOrDefault());
        Assert.Equal("Test Journal 2", result[1].Title);
    }

    [Fact]
    public async Task ProcessResponse_ShouldSetRateLimitHeaders()
    {
        // Arrange
        HttpResponseMessage response = new()
        {
            StatusCode = HttpStatusCode.OK,
            Headers =
            {
                { "X-Rate-Limit-Limit", "5" },
                { "X-Rate-Limit-Interval", "1s" },
            },
        };

        // Act
        _crossrefService.GetType()
            .GetMethod("ProcessResponse", BindingFlags.NonPublic | BindingFlags.Instance)
            ?.Invoke(_crossrefService, [response]);

        // Assert
        Assert.Equal(5,
            _crossrefService.GetType().GetField("_rateLimitLimit", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.GetValue(_crossrefService));
        Assert.Equal(1,
            _crossrefService.GetType().GetField("_rateLimitInterval", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.GetValue(_crossrefService));
    }
}
