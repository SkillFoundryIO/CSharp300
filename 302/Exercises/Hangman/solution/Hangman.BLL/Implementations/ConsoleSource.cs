using Hangman.BLL.Interfaces;

namespace Hangman.BLL.Implementations
{
    public class ConsoleSource : IWordSource
    {
        public string GetWord()
        {
            string input;

            do
            {
                Console.Write($"Enter word: ");
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
