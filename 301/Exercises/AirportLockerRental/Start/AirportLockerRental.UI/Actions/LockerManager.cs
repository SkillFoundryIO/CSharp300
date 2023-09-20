using AirportLockerRental.UI.DTOs;

namespace AirportLockerRental.UI.Actions
{
    public class LockerManager
    {
        private LockerContents[] _lockers = new LockerContents[100];

        public void ListContents()
        {
            for (int i = 0; i < _lockers.Length; i++)
            {
                if (_lockers[i] != null)
                {
                    ConsoleIO.DisplayLockerContents(_lockers[i], i + 1);
                }
            }
        }

        public LockerContents ViewLocker(int number)
        {
            return _lockers[number - 1];
        }

        public bool CanRentLocker(int number)
        {
            return _lockers[number - 1] == null;
        }

        public bool RentLocker(int number, LockerContents contents)
        {
            if(CanRentLocker(number))
            {
                _lockers[number - 1] = contents;
                return true;
            }

            return false;
        }

        public LockerContents EndRental(int number)
        {
            if(CanRentLocker(number))
            {
                return null;
            }
            else
            {
                LockerContents contents = _lockers[number - 1];
                _lockers[number - 1] = null;
                return contents;
            }
        }
    }
}
