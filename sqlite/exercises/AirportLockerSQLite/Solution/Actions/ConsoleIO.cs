using AirportLockerSQLite.Entities;

namespace AirportLockerSQLite.Actions;

public static class ConsoleIO
{
    public static string GetRequiredString(string prompt)
    {
        do
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("This data is required.");
                AnyKey();
            }
        } while (true);
    }

    public static void AnyKey()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public static int DisplayAccountMenu()
    {
        Console.WriteLine("Welcome to Airport Locker Rental!\n\n1. Login\n2. Create an Account\n3. Quit\n");
        return GetMenuChoice(1, 3);
    }

    public static int GetMenuChoice(int min, int max)
    {
        do
        {
            Console.Write($"Enter choice: ");
            int choice;

            if(int.TryParse(Console.ReadLine(), out choice))
            {
                if (choice >= min && choice <= max)
                {
                    return choice;
                }
            }

            Console.WriteLine($"Please enter a valid option between {min} and {max}.");

        } while (true);       
    }

    public static void PrintHeading(string headerText)
    {
        Console.Clear();
        Console.WriteLine($"{headerText}");
        Console.WriteLine(new String('=', headerText.Length));
    }

    public static int DisplayLockerMenu(User user)
    {
        Console.Clear();
        Console.WriteLine(@$"Welcome {user.UserName}

1.Rent a Locker
2.End a Rental
3.View Rentals
4.Log Out
");

        return GetMenuChoice(1, 4);
    }

    public static int GetLockerNumber(int capacity)
    {
        do
        {
            Console.Write($"Enter locker # (1 - {capacity}): ");
            int lockerNumber;

            if (int.TryParse(Console.ReadLine(), out lockerNumber))
            {
                if (lockerNumber >= 1 && lockerNumber <= capacity)
                {
                    return lockerNumber;
                }
            }

            Console.WriteLine($"Please enter a valid option between 1 and {capacity}.");

        } while (true);
    }

    public static int GetLockerNumberFromList(IEnumerable<int> rentedNumbers)
    {
        do
        {
            Console.WriteLine($"Rented Lockers: {string.Join(",", rentedNumbers)}");
            Console.Write("Enter locker number: ");

            int lockerNumber;

            if (int.TryParse(Console.ReadLine(), out lockerNumber))
            {
                if (rentedNumbers.Contains(lockerNumber))
                {
                    return lockerNumber;
                }
            }

            Console.WriteLine("Invalid locker number!");
        } while (true);
    }
}
