using AirportLockerRental.UI.Actions;
using AirportLockerRental.UI.DTOs;

namespace AirportLockerRental.UI.Storage
{
    public class DictionaryLockerRepository : ILockerRepository
    {
        private Dictionary<int, LockerContents> _storage = new Dictionary<int, LockerContents>();

        public int Capacity { get; set; }

        public DictionaryLockerRepository(int capacity)
        {
            Capacity = capacity;
        }

        public LockerContents? Remove(int number)
        {
            if (_storage.ContainsKey(number))
            {
                var item = _storage[number];
                _storage.Remove(number);
                return item;
            }

            return null;
        }

        public LockerContents? Get(int number)
        {
            if(_storage.ContainsKey(number))
            {
                return _storage[number];
            }

            return null;
        }

        public bool IsAvailable(int number)
        {
            return !_storage.ContainsKey(number);
        }

        public void List()
        {
            foreach(var key in _storage.Keys)
            {
                ConsoleIO.DisplayLockerContents(_storage[key]);
            }
        }

        public bool Add(LockerContents contents)
        {
            if(_storage.ContainsKey(contents.LockerNumber) || _storage.Count >= Capacity)
            {
                return false;
            }

            _storage.Add(contents.LockerNumber, contents);

            return true;
        }
    }
}
