using Hangman.BLL.Interfaces;

namespace Hangman.BLL.Implementations
{
    public class HumanPlayer : IPlayer
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public IWordSource WordSource { get; set; }

        public HumanPlayer(string name, IWordSource wordSource)
        {
            Name = name;
            WordSource = wordSource;
        }

        public string GetGuess()
        {
            string input;

            do
            {
                Console.Write($"Enter Guess: ");
                input = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input.ToUpper();
                }

                Console.WriteLine("Invalid input. Try again!");
            } while (true);
        }
    }
}
