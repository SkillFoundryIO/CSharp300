
using LibraryManagement.Core.Entities;

namespace LibraryManagement.ConsoleUI.IO
{
    public class Utilities
    {
        public static void AnyKey()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        public static int GetPositiveInteger(string prompt)
        {
            int result;

            do
            {
                Console.Write(prompt);
                if(int.TryParse(Console.ReadLine(), out result))
                {
                    if(result > 0)
                    {
                        return result;
                    }
                }

                Console.WriteLine("Invalid input, must be a positive integer!");
                AnyKey();
            } while (true);
        }

        public static string GetRequiredString(string prompt)
        {
            string? input;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }

                Console.WriteLine("Input is required.");
                AnyKey();
            } while (true);
        }
    }
}
