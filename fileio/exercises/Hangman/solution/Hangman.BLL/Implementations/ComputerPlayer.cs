using Hangman.BLL.Interfaces;

namespace Hangman.BLL.Implementations
{
    public class ComputerPlayer : IPlayer
    {
        private List<string> _alphabet = new List<string>() { "A", "B", "C", "D", "E", "F",
            "G", "H", "I", "J", "K", "L", "M", "N", "O", "P",
            "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

        private Random _rng = new Random();

        public string Name { get; set; }
        public int Wins { get; set; }
        public IWordSource WordSource { get; set; }

        public ComputerPlayer(string name, IWordSource wordSource)
        {
            Name = name;
            WordSource = wordSource;
        }

        /// <summary>
        /// Picks a random index from the alphabet then removes it so it won't be used twice.
        /// </summary>
        /// <returns>The letter guess selected randomly</returns>
        public string GetGuess()
        {
            int index = _rng.Next(0, _alphabet.Count());

            string selection = _alphabet[index];
            _alphabet.RemoveAt(index);

            // to make it look like the human player
            Console.WriteLine($"Enter Guess: {selection}");
            return selection;
        }
    }
}
