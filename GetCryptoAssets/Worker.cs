using System.Text.Json;

namespace GetCryptoAssets;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly HttpClient _httpClient;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
        _httpClient = new HttpClient();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _logger.LogInformation("Fetching data from API at: {time}", DateTimeOffset.Now);
                var response = await _httpClient.GetAsync("https://api.example.com/data", stoppingToken);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync(stoppingToken);
                var data = JsonSerializer.Deserialize<object>(content);

                _logger.LogInformation("Received data: {data}", content);

                // Process the data here...

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching data from API");
            }

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Worker is stopping.");
        _httpClient.Dispose();
        await base.StopAsync(cancellationToken);
    }
}