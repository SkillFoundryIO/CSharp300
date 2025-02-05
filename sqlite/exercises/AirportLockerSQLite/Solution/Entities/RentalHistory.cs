namespace AirportLockerSQLite.Entities;

public class RentalHistory
{
    public int RentalID { get; set; }
    public int UserID { get; set; }
    public int LockerNumber { get; set; }
    public string Contents { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public User User { get; set; } = null!;
}
