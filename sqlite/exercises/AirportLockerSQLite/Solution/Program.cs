using AirportLockerSQLite;
using Microsoft.Extensions.Configuration;

var configBuilder = new ConfigurationBuilder()
        .AddUserSecrets<Program>()
        .Build();

var settings = new Settings();

settings.ConnectionString = configBuilder["ConnectionStrings:LockerDb"] ?? null;
settings.PassPhrase = configBuilder["Security:PassPhrase"] ?? null;
settings.LockerCapacity = int.Parse(configBuilder["LockerCapacity"]);

if (string.IsNullOrEmpty(settings.ConnectionString) || string.IsNullOrEmpty(settings.PassPhrase))
{
    throw new Exception("Invalid User Secrets Configuration");
}

var app = new App(settings);
app.Run();