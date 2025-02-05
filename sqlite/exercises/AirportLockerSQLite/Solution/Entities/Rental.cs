namespace AirportLockerSQLite.Entities;

public class Rental
{
    public int LockerNumber { get; set; }
    public int UserID { get; set; }
    public string Contents { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }

    public User User { get; set; } = null!;
}
