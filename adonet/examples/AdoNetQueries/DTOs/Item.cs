namespace AdoNetQueries.DTOs;

public class Item
{
    public int ItemID { get; set; }
    public Category Category { get; set; } = new Category();
    
    public string? ItemName { get; set; }
    public string? ItemDescription { get; set; }
    public List<ItemPrice> Prices { get; set; } = new List<ItemPrice>();
}

