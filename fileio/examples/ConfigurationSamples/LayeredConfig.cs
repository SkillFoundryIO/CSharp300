using Microsoft.Extensions.Configuration;

namespace ConfigurationSamples;

public class LayeredConfig
{
    public static void DemonstrateConfig()
    {
        var configBuilder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables()
            .Build();

        // from file
        var apiKey = configBuilder["API_KEY"] ?? null;

        // from secrets
        var alertEmail = configBuilder["AlertEmail"] ?? null;

        // from environment
        var temp = configBuilder["TEMP"] ?? null;

        Console.WriteLine($"{apiKey}\n{alertEmail}\n{temp}");
    }
}