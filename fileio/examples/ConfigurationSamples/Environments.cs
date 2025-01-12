using Microsoft.Extensions.Configuration;

namespace ConfigurationSamples;

public class Environments
{
    public static void DemonstrateEnvironment()
    {
        // direct access
        var tempDirectory = Environment.GetEnvironmentVariable("TEMP");
        Console.WriteLine(tempDirectory);

        // using Config
        var configBuilder = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .Build();

        var temp = configBuilder["TEMP"] ?? null;

        Console.WriteLine(temp);
        
    }
}