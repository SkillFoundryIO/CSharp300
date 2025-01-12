using Microsoft.Extensions.Configuration;

namespace ConfigurationSamples;
public class UserSecrets
{
    public static void DemonstrateConfig()
    {
        var configBuilder = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();

        var alertEmail = configBuilder["AlertEmail"] ?? null;

        Console.WriteLine($"Send alerts to: {alertEmail}");
    }
}