using System.Text.Json;
using System.Text.Json.Serialization;
using DoiTools.Net;

namespace Crossref.Net.Services;

public class CrossrefServiceOptions
{
    /// <summary>
    /// The base URL for the Crossref API.
    /// </summary>
    /// <value>The default value is <c>"https://api.crossref.org/"</c>.</value>
    public string BaseUrl { get; set; } = "https://api.crossref.org";

    /// <summary>
    /// The email address to identify yourself and be in the "polite pool"
    /// </summary>
    public string Mailto { get; set; } = "mailto:crossref@crossref.net";

    /// <summary>
    /// The user agent to identify yourself
    /// </summary>
    public string UserAgent { get; set; } = "Crossref.Net";

    /// <summary>
    /// The options for the JSON serializer.
    /// </summary>
    /// <value>
    /// The default value is a new instance of <see cref="JsonSerializerOptions" /> with the following settings:
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="System.Text.Json.JsonSerializerOptions.PropertyNamingPolicy" /> =
    /// <see cref="JsonNamingPolicy.SnakeCaseLower" />
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="JsonSerializerOptions.Converters" /> = { new <see cref="JsonStringEnumConverter" /> (
    /// <see cref="JsonNamingPolicy.SnakeCaseLower" />) }
    /// </description>
    /// </item>
    /// </list>
    /// </value>
    public JsonSerializerOptions JsonSerializerOptions { get; set; } = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        Converters =
        {
            new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower),
            new DoiConverter(),
        },
    };
}
