using AirportLockerRental.UI.DTOs;

namespace AirportLockerRental.UI.Actions
{
    public static class ConsoleIO
    {
        public static string GetRequiredString(string prompt)
        {
            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if(!string.IsNullOrEmpty(input))
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

        public static void DisplayLockerContents(LockerContents dto, int lockerNumber)
        {
            if (dto == null)
            {
                Console.WriteLine("=====================================");
                Console.WriteLine($"Locker #: {lockerNumber}");
                Console.WriteLine($"Renter Name: N/A");
                Console.WriteLine($"Contents: Empty");
                Console.WriteLine("=====================================");
            }
            else
            {
                Console.WriteLine("=====================================");
                Console.WriteLine($"Locker #: {lockerNumber}");
                Console.WriteLine($"Renter Name: {dto.RenterName}");
                Console.WriteLine($"Contents: {dto.Description}");
                Console.WriteLine("=====================================");
            }
        }

        public static int GetLockerNumber()
        {
            int lockerNumber;

            do
            {
                Console.Write("Enter locker number (1-100): ");
                if (int.TryParse(Console.ReadLine(), out lockerNumber))
                {
                    if (lockerNumber >= 1 && lockerNumber <= 100)
                    {
                        return lockerNumber;
                    }

                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 100.");
                }
            } while (true);
        }

        public static int GetMenuOption()
        {
            int userChoice;

            Console.Clear();

            do
            {
                Console.Clear();
                Console.WriteLine("Airport Locker Rental Menu");
                Console.WriteLine("=============================");
                Console.WriteLine("1. View a locker");
                Console.WriteLine("2. Rent a locker");
                Console.WriteLine("3. End a locker rental");
                Console.WriteLine("4. List all locker contents");
                Console.WriteLine("5. Quit");
                Console.Write("\nEnter your choice (1-5): ");

                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    if (userChoice >= 1 && userChoice <= 5)
                    {
                        return userChoice;
                    }

                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    AnyKey();
                }
            } while (true);
        }

        public static void AnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static LockerContents GetLockerContentsFromUser()
        {
            LockerContents contents = new LockerContents();

            contents.RenterName = ConsoleIO.GetRequiredString("Enter your name: ");
            contents.Description = ConsoleIO.GetRequiredString("Enter the item you want to store in the locker: ");

            return contents;
        }
    }
}
