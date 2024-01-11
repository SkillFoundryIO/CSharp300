namespace CSVExample
{
    public class InventoryIO
    {
        private const string _filePath = "inventory.csv";
        private const string _headerRow = "SKU,ProductName,StockQty,UnitPrice,Rating,Notes";
        public InventoryIO()
        {
            if (!File.Exists(_filePath))
            {
                using (StreamWriter sw = new StreamWriter(_filePath))
                {
                    sw.WriteLine(_headerRow);
                }
            }
        }

        public List<Inventory> ReadDataFromFile()
        {
            List<Inventory> inventories = new List<Inventory>();

            using (StreamReader sr = new StreamReader(_filePath))
            {
                sr.ReadLine(); // skip header

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] parts = line.Split(',');

                    inventories.Add(new Inventory
                    {
                        SKU = parts[0],
                        ProductName = parts[1],
                        StockQty = int.Parse(parts[2]),
                        UnitPrice = decimal.Parse(parts[3]),
                        Rating = byte.TryParse(parts[4], out byte rating) ? rating : null,
                        Notes = parts[5]
                    });
                }
            }

            return inventories;
        }

        public void AddItemToFile(Inventory inv)
        {
            using (StreamWriter sw = new StreamWriter(_filePath, true)) // true to append to file
            {
                sw.WriteLine($"{inv.SKU},{inv.ProductName},{inv.StockQty},{inv.UnitPrice},{inv.Rating},{inv.Notes}");
            }            
        }

        public bool UpdateItemInFile(Inventory newItem)
        {
            List<Inventory> inventories = ReadDataFromFile();
            int index = inventories.FindIndex(i => i.SKU == newItem.SKU);
            if (index == -1)
            {
                return false;
            }

            inventories[index] = newItem;

            using(StreamWriter sw = new StreamWriter(_filePath))
            {
                sw.WriteLine(_headerRow); // header
                foreach (var item in inventories)
                {
                    sw.WriteLine($"{item.SKU},{item.ProductName},{item.StockQty},{item.UnitPrice},{item.Rating},{item.Notes}");
                }
            }

            return true;
        }
    }
}
