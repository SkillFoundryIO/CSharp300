using Microsoft.Extensions.Configuration;

var configBuilder = new ConfigurationBuilder()
   .AddJsonFile("appsettings.json")
   .AddUserSecrets<Program>()
   .AddEnvironmentVariables()
   .Build();

#region "JSON appsettings"

// get the section to read
var configSection = configBuilder.GetSection("AppSettings");

// get the configuration values in the section.
var apiKey = configSection["API_Key"] ?? null;
var logDirectory = configSection["LogDir"] ?? null;
var db = configSection["ConnectionStrings:4WS"] ?? null;

Console.WriteLine($"API Key: {apiKey}");
Console.WriteLine($"Log Directory: {logDirectory}");
Console.WriteLine($"4WS Connection String: {db}");
#endregion

#region "User Secrets"
var secretAPIKey = configBuilder["API_Key"] ?? null;
Console.WriteLine($"Secrets API Key: {secretAPIKey}");
#endregion

#region "Environment"
var tempdir = Environment.GetEnvironmentVariable("TEMP");
Console.WriteLine($"Temp directory: {tempdir}");

tempdir = configBuilder["TEMP"];
Console.WriteLine($"Temp directory 2: {tempdir}");
#endregion