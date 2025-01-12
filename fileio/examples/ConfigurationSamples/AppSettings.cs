using Microsoft.Extensions.Configuration;

namespace ConfigurationSamples;

public class AppSettings
{
    public static void DemonstrateConfig()
    {
        var configBuilder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        // Using null operator in case the key isn't found
        var apiKey = configBuilder["API_KEY"] ?? null;

        Console.WriteLine(apiKey);

        // load a section
        var connectionStrings = configBuilder.GetSection("ConnectionStrings");

        // get values from the section
        var local = connectionStrings["LocalDB"] ?? null;
        var qa = connectionStrings["QADB"] ?? null;

        Console.WriteLine($"Local: {local}\nQA:{qa}");

        // access sections via : symbol
        var localDB = configBuilder["ConnectionStrings:LocalDB"] ?? null;
        Console.WriteLine($"{localDB}");
    }
}