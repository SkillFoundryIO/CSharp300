namespace CafePOS.ConsoleUI.IO
{
    public class Utilities
    {
        public static int GetChoiceInRange(int low, int high)
        {
            int choice;

            do
            {
                SystemPromptCyan($"\nEnter your choice ({low}-{high}): ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice >= low && choice <= high)
                    {
                        return choice;
                    }
                }

                SystemMessageRed("Invalid choice!");
            } while (true);
        }

        public static int GetPositiveInteger(string prompt)
        {
            int result;

            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                SystemPromptCyan(prompt);
                Console.ResetColor();

                if (int.TryParse(Console.ReadLine(), out result))
                {
                    if (result > 0)
                    {
                        return result;
                    }
                }
                SystemMessageRed("Invalid input, must be a positive integer!");
                AnyKey();
            } while (true);
        }

        public static int GetIntZeroOrHigher(string prompt)
        {
            int result;

            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                SystemPromptCyan(prompt);
                Console.ResetColor();

                if (int.TryParse(Console.ReadLine(), out result))
                {
                    if (result >= 0)
                    {
                        return result;
                    }
                }
                SystemMessageRed("Invalid input, must be zero or higher!");
                AnyKey();
            } while (true);
        }

        public static decimal GetTipAmount(string prompt)
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                SystemPromptCyan(prompt);
                Console.ResetColor();

                if(decimal.TryParse(Console.ReadLine(), out decimal amount))
                if (amount >= 0)
                {
                    return amount;
                }
                Console.ResetColor();
                SystemMessageRed("Negative numbers are not allowed.");
                AnyKey();
            } while (true);
        }

        public static DateTime GetDate(string prompt)
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                SystemPromptCyan(prompt);
                Console.ResetColor();

                if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                    if (date <= DateTime.Today)
                    {
                        return date;
                    }
                Console.ResetColor();
                SystemMessageRed("Future dates are not allowed.");
                AnyKey();
            } while (true);
        }

        public static void AnyKey()
        {
            SystemMessageGreen("\nPress any key to continue...");
            Console.ReadKey();
        }

        public static bool AddMoreItems()
        {
            string input;
            do
            {
                SystemPromptCyan("\nDo you want to add more items? Y/N: ");
                input = Console.ReadLine().ToUpper();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    if (input == "N")
                    {
                        return false;
                    }
                    if (input == "Y")
                    {
                        return true;
                    }
                    else
                    {
                        SystemMessageRed("That was not a valid input. Try again.");
                        AnyKey();
                    }
                }
            } while (true);
        }

        public static void SystemMessageRed(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void SystemMessageGreen(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void SystemPromptCyan(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(message);
            Console.ResetColor();
        }

        public static void DisplayMenuHeader(string title)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('-', 100));
            Console.WriteLine($"Fourth Wall Cafe  --  {title}");
            Console.WriteLine(new string('-', 100));
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
