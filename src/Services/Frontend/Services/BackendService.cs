using Frontend.Models.Configuration;
using System.Net;

namespace Frontend.Services;

public class BackendService : IBackendService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseAddress;
    private readonly ILogger<BackendService> _logger;

    public BackendService(HttpClient httpClient, ApiConfiguration apiConfiguration, ILogger<BackendService> logger)
    {
        _httpClient = httpClient;
        _baseAddress = apiConfiguration.BackendHost;
        _logger = logger;
    }

    public async Task<string> GetBackendApiContent()
    {
        var response = await _httpClient.GetAsync($"{_baseAddress}/content/get");

        if (response.StatusCode != HttpStatusCode.OK)
        {
            var content = await response.Content.ReadAsStringAsync();
            _logger.LogError($"Non-HTTP200 return code: {response.StatusCode} ({content})");
            _logger.LogError(response.ReasonPhrase);
            return "The API returned an error";
        }

        return await response.Content.ReadAsStringAsync();
    }
}
