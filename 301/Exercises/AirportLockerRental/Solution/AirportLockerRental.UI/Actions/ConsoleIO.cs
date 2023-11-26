using AirportLockerRental.UI.DTOs;
using AirportLockerRental.UI.Storage;

namespace AirportLockerRental.UI.Actions
{
    public static class ConsoleIO
    {
        public static string GetRequiredString(string prompt)
        {
            do
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

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

        public static int GetCapacity()
        {
            int capacity;

            do
            {
                Console.Write("Enter storage capacity: ");
                if(int.TryParse(Console.ReadLine(), out capacity))
                {
                    if(capacity > 0)
                    {
                        return capacity;
                    }
                }

                Console.WriteLine("Capacity must be a positive number.");
                AnyKey();
            } while (true);
        }

        public static ILockerRepository GetStorageType()
        {
            int choice;

            Console.WriteLine("Choose storage type");
            Console.WriteLine("===================");
            Console.WriteLine("1. Array");
            Console.WriteLine("2. Dictionary");
            Console.WriteLine("");

            do
            {
                Console.Write("Enter choice (e.g. 1): ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice == 1)
                    {
                        return new ArrayLockerRepository(GetCapacity());
                    }
                    else if (choice == 2)
                    {
                        return new DictionaryLockerRepository(GetCapacity());
                    }
                }

                Console.WriteLine("You must choose a valid storage type");
                AnyKey();
            } while (true);
        }

        public static void DisplayLockerContents(LockerContents? dto)
        {
            if(dto != null)
            {
                Console.WriteLine("=====================================");
                Console.WriteLine($"Locker #: {dto.LockerNumber}");
                Console.WriteLine($"Renter Name: {dto.RenterName}");
                Console.WriteLine($"Contents: {dto.Description}");
                Console.WriteLine("=====================================");
            }
        }

        public static int GetLockerNumber(int capacity)
        {
            int lockerNumber;

            do
            {
                Console.Write($"Enter locker number (1-{capacity}): ");
                if (int.TryParse(Console.ReadLine(), out lockerNumber))
                {
                    if (lockerNumber >= 1 && lockerNumber <= capacity)
                    {
                        return lockerNumber;
                    }

                    Console.WriteLine($"Invalid choice. Please enter a number between 1 and {capacity}.");
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

            contents.RenterName = GetRequiredString("Enter your name: ");
            contents.Description = GetRequiredString("Enter the item you want to store in the locker: ");

            return contents;
        }
    }
}
