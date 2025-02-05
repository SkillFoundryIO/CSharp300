namespace AirportLockerSQLite.Entities;

public class User
{
    public int UserID { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Salt { get; set; } = string.Empty;

    public List<Rental> Rentals { get; set; } = new();
    public List<RentalHistory> RentalHistory { get; set; } = new();
}
