namespace Hangman.UI
{
    public class ConsoleIO
    {
        public static void AnyKey()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        public static string GetPlayerType(int num)
        {
            string input;

            do
            {
                Console.Write($"Is player {num} a (h)uman or (c)omputer? ");
                input = Console.ReadLine() ?? "";
                input = input.ToUpper();
                if (input != null && (input == "H" || input == "C"))
                {
                    return input;
                }

                Console.WriteLine("Invalid input. Try again!");
                AnyKey();
            } while (true);
        }

        public static string GetPlayerName(int num)
        {
            string input;

            do
            {
                Console.Write($"Enter player {num}'s name: ");
                input = Console.ReadLine() ?? "";

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }

                Console.WriteLine("Invalid input. Try again!");
                AnyKey();
            } while (true);
        }

        public static bool PlayAgain()
        {
            string input;

            do
            {
                Console.Write("Play another game (y/n): ");
                input = Console.ReadLine() ?? "";
                input = input.ToUpper();

                if(input == "Y")
                {
                    return true;
                }
                else if (input == "N")
                {
                    return false;
                }

                Console.WriteLine("Invalid choice! Try again!");
            } while (true);
            
        }
    }
}
