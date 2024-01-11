using System.Text.Json;

namespace JsonExample
{
    public class InventoryIO
    {
        private const string _filePath = "inventory.json";
        private static JsonSerializerOptions _options = new JsonSerializerOptions { WriteIndented = true };

        public InventoryIO()
        {
            if(!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }

        public List<Inventory> ReadDataFromFile()
        {
            string fileContent = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Inventory>>(fileContent) ?? new List<Inventory>();
        }

        public void AddItemToFile(Inventory inv)
        {
            var inventories = ReadDataFromFile();
            inventories.Add(inv);
            File.WriteAllText(_filePath, JsonSerializer.Serialize(inventories, _options));
        }

        public bool UpdateItemInFile(Inventory updatedItem)
        {
            var inventories = ReadDataFromFile();
            int index = inventories.FindIndex(i => i.SKU == updatedItem.SKU);

            if (index == -1)
            {
                return false;
            }

            inventories[index] = updatedItem;
            File.WriteAllText(_filePath, JsonSerializer.Serialize(inventories, _options));

            return true;
        }
    }
}
