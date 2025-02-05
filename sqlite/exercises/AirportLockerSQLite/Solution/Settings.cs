namespace AirportLockerSQLite;

public class Settings
{
    public string PassPhrase { get; set; } = string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
    public int LockerCapacity { get; set; }
}
