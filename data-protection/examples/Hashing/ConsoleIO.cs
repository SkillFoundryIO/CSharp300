namespace Hashing;

public static class ConsoleIO
{
    public static string GetRequiredString(string prompt)
    {
        while(true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if(!string.IsNullOrEmpty(input))
            {
                return input;
            }

            Console.WriteLine("Invalid input!");
        }
    }

}
