using Hangman.BLL.Implementations;
using Hangman.BLL.Interfaces;

namespace Hangman.UI
{
    public static class PlayerFactory
    {
        public static IPlayer CreatePlayer(int num)
        {
            IPlayer player;
            player = GetInstanceFromType(ConsoleIO.GetPlayerType(num), num);
            return player;
        }

        private static IPlayer GetInstanceFromType(string playerType, int num)
        {
            IPlayer instance;

            if(playerType == "C")
            {
                instance = new ComputerPlayer($"Player {num}", new DictionarySource());
                Console.WriteLine($"The computer has been assigned the name '{instance.Name}' and will pick a random word from the dictionary.");
            }
            else
            {
                string name = ConsoleIO.GetPlayerName(num);
                IWordSource wordSource = GetWordSourceInstanceForPlayer(name);
                instance = new HumanPlayer(name, wordSource);
            }

            return instance;
        }

        private static IWordSource GetWordSourceInstanceForPlayer(string name)
        {
            Console.Write($"\n{name}, how would you like to choose your words?");

            Console.WriteLine("\n1. I will choose the word.");
            Console.WriteLine("2. Pick a random word from the dictionary for me.\n");

            string input;

            do
            {
                Console.Write("Enter choice: ");
                input = Console.ReadLine() ?? "";

                if (input == "1")
                {
                    return new ConsoleSource();
                }
                else if (input == "2")
                {
                    return new DictionarySource();
                }
                else
                {
                    Console.WriteLine("Invalid choice! Try again!");
                }
            } while (true);
        }
    }
}
