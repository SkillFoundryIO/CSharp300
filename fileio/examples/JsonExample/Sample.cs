namespace JsonExample
{
    public class Sample
    {
        public static void AddData()
        {
            var inv = new InventoryIO();

            inv.AddItemToFile(new Inventory
            {
                SKU = "12345",
                ProductName = "Widget",
                Rating = 10,
                StockQty = 5,
                UnitPrice = 4.99M,
                Notes = "The widget every household needs."
            });

            inv.AddItemToFile(new Inventory
            {
                SKU = "67890",
                ProductName = "Thingamabob",
                StockQty = 1,
                UnitPrice = 9.99M,
                Notes = "Our world famous thingamabob."
            });
        }

        public static void Update()
        {
            var inv = new InventoryIO();

            var updated = new Inventory
            {
                SKU = "67890",
                ProductName = "Thingamabob v2",
                StockQty = 1,
                UnitPrice = 9.99M,
                Notes = "Our world famous thingamabob improved"
            };

            inv.UpdateItemInFile(updated);
        }

        public static void PrintContents()
        {
            var inv = new InventoryIO();

            foreach (var item in inv.ReadDataFromFile())
            {
                Console.WriteLine($"{item.SKU} {item.ProductName,-20} {item.UnitPrice,6:c} {item.StockQty,2} {(item.Rating.HasValue ? item.Rating.Value : "N/A"),5} {item.Notes}");
            }
        }

        public static void Reset()
        {
            if (File.Exists("inventory.json"))
            {
                File.Delete("inventory.json");
            }
        }
    }
}
