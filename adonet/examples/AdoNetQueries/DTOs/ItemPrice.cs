namespace AdoNetQueries.DTOs;

public class ItemPrice
{
    public int ItemPriceID { get; set; }
    public decimal Price { get; set; }
    public string? TimeOfDayName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
