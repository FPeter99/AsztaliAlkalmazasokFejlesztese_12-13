using System.Net.Http.Headers;
using System.Text.Json;

namespace HuTierLib;

public class HuTierApiHandler
{
    readonly HttpClient _httpClient;

    public HuTierApiHandler(string base_url)
    {
        _httpClient = new HttpClient()
        {
            BaseAddress = new Uri(base_url)
        };
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public record TestResult(string id, string player_uuid, string username, bool banned, bool full_retired,
                             string gamemode, string rank, int points, string? created_at, string? updated_at,
                             bool retired, bool tester, bool is_tester, int overall_position, int full_retired_position);

    public record TestsResponse(TestResult[] tests, bool banned, bool fullRetired,
                                Dictionary<string, bool> testerByGamemode, Dictionary<string, bool> retiredByGamemode);

    public record SingleTestResponse(TestResult? test, bool banned, bool fullRetired,
                                     Dictionary<string, bool> testerByGamemode, Dictionary<string, bool> retiredByGamemode);

    public async Task<T?> GetAsync<T>(string path, CancellationToken cancellationToken)
    {
        T? response = default;
        try
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync(path, cancellationToken);
            if (responseMessage.IsSuccessStatusCode)
            {
                string str = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
                response = JsonSerializer.Deserialize<T>(str);
            }
            else
            {
                Console.WriteLine($"HTTP hiba: {(int)responseMessage.StatusCode} {responseMessage.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hiba: " + ex.Message);
            if (ex.InnerException != null)
            {
                Console.WriteLine("Belső hiba: " + ex.InnerException.Message);
            }
        }
        return response;
    }
}