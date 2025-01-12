using AirportLockerRental.UI.Actions;
using AirportLockerRental.UI.DTOs;

namespace AirportLockerRental.UI.Storage
{
    public class ArrayLockerRepository : ILockerRepository
    {
        private LockerContents?[] _storage;

        public int Capacity { get; set; }

        public ArrayLockerRepository(int capacity)
        {
            Capacity = capacity;
            _storage = new LockerContents?[capacity];
        }

        public LockerContents? Remove(int number)
        {
            if (_storage[number-1] != null)
            {
                LockerContents? contents = _storage[number - 1];
                _storage[number - 1] = null;
                return contents;
            }

            return null;
        }

        public LockerContents? Get(int number)
        {
            return _storage[number - 1];
        }

        public bool IsAvailable(int number)
        {
            return _storage[number - 1] == null;
        }

        public void List()
        {
            for (int i = 0; i < _storage.Length; i++)
            {
                if (_storage[i] != null)
                {
                    ConsoleIO.DisplayLockerContents(_storage[i]);
                }
            }
        }

        public bool Add(LockerContents contents)
        {
            // locker number in range?
            int index = contents.LockerNumber - 1;
            if (index < 0 || index > Capacity - 1)
            {
                return false;
            }

            if (IsAvailable(contents.LockerNumber))
            {
                _storage[index] = contents;
                return true;
            }

            return false;
        }
    }
}
