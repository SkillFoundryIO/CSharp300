using AirportLockerRental.UI.DTOs;
using System.Text.Json;

namespace AirportLockerRental.UI.Storage
{
    public class JsonLockerRepository : DictionaryLockerRepository
    {
        public JsonLockerRepository(int capacity) : base(capacity)
        {
            Load();
        }

        public override bool Add(LockerContents contents)
        {
            var result = base.Add(contents);

            if(result)
            {
                Save();
            }

            return result;
        }

        public override LockerContents? Remove(int number)
        {
            var item = base.Remove(number);

            if (item != null) 
            {
                Save();
            }

            return item;
        }

        public void Load()
        {
            if(File.Exists("lockers.json"))
            {
                string fileJson = File.ReadAllText("lockers.json");
                _storage = JsonSerializer.Deserialize<Dictionary<int, LockerContents>>(fileJson) ?? new Dictionary<int, LockerContents>();
            }            
        }

        public void Save()
        {
            string fileContents = JsonSerializer.Serialize(_storage);

            File.WriteAllText("lockers.json", fileContents);
        }
    }
}
