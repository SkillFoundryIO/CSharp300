using Microsoft.Extensions.Configuration;

namespace ConfigurationSamples;

public class CommandLine
{
    public static void DemonstrateCommandLine(string[] args)
    {
        // note, you must run the app with the command line argument for this to work!
        var configBuilder = new ConfigurationBuilder()
            .AddCommandLine(args)
            .Build();

        var val = configBuilder["alertEmail"];

        if(val == null)
        {
            Console.WriteLine("You must provide an 'alertEmail' argument.");
        }
        else
        {
            Console.WriteLine(val);
        }
    }
}