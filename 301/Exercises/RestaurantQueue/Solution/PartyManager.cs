namespace RestaurantQueue
{
    public class PartyManager
    {
        private Queue<Party> _guestQueue;

        public PartyManager()
        {
            _guestQueue = new Queue<Party>();
        }

        public void AddParty(Party guest)
        {
            _guestQueue.Enqueue(guest);
        }

        public Party CallParty()
        {
            if(_guestQueue.Count > 0)
            {
                return _guestQueue.Dequeue();
            }

            return null;
        }

        public bool RemoveParty(string lastName)
        {
            // Using a temporary queue to store remaining guests after removal
            Queue<Party> tempQueue = new Queue<Party>();
            bool found = false;
            while (_guestQueue.Count > 0)
            {
                var guest = _guestQueue.Dequeue();
                if (guest.LastName != lastName)
                {
                    tempQueue.Enqueue(guest);
                }
                else
                {
                    found = true;
                }
            }

            _guestQueue = tempQueue;
            return found;
        }

        public void ListParties()
        {
            ConsoleIO.ListGuests(_guestQueue);
        }

        public Party OnDeckParty()
        {
            return _guestQueue.Count > 0 ? _guestQueue.Peek() : null;
        }
    }
}
