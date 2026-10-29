using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using WestcoastEducation.Core.Interfaces;

namespace WestcoastEducation.Core.Services;

public class HttpService<T> : IHttpService<T> where T : class
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = string.Empty;

    //RestDb skickar camelCase
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        WriteIndented = true
    };

    public HttpService()
    {
        // Läser inställningar från appsettings.json
        var config = new ConfigurationBuilder() // Skapa en byggare
            .AddJsonFile("appsettings.json") // lägg till filen
            .Build(); // bygg

        // Hämtar API-nyckel och adress från Settings-sektionen
        var apiKey = config.GetSection("Settings:ApiKey").Value!;
        _baseUrl = config.GetSection("Settings:BaseUrl").Value!;

        // Klienten får grundadressen en gång, så behöver varje anrop endast collectionens namn
        _httpClient = new HttpClient()
        {
            BaseAddress = new Uri(_baseUrl)
        };
        // Hämta alltid färsk data istället för sparad kopia
        _httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
        // RestDb kräver API-nyckel i varje anrop
        _httpClient.DefaultRequestHeaders.Add("x-apikey", apiKey);
    }

    public async Task<List<T>> Get(string resource)
    {
        // 1. Skicka förfrågan och vänta på svar
        var response = await _httpClient.GetAsync(resource);
        // 2. Gick det inte, lämna tillbaka en tom lista
        if (!response.IsSuccessStatusCode)
            return [];

        // 3. Läs svaret som text
        var result = await response.Content.ReadAsStringAsync();

        // 4. Gör om JSON-texten till en lista med T
        var data = JsonSerializer.Deserialize<List<T>>(result, _options) ?? [];
        return data;
    }
}