using AirportLockerRental.UI.Actions;
using AirportLockerRental.UI.DTOs;
using AirportLockerRental.UI.Storage;

namespace AirportLockerRental.UI.Workflows
{
    // we only need one App object, so making it static is appropriate
    public static class App
    {
        public static void Run()
        {
            // instantiate a locker manager to do the work
            ILockerRepository lockerStorage = ConsoleIO.GetStorageType();

            while (true)
            {
                int choice = ConsoleIO.GetMenuOption();

                if(choice == 5)
                {
                    return;
                }
                else if(choice == 4)
                {
                    lockerStorage.List();
                }
                else
                {
                    // we need a locker number for these three choices
                    int lockerNumber = ConsoleIO.GetLockerNumber(lockerStorage.Capacity);

                    if(choice == 1)
                    {
                        LockerContents contents = lockerStorage.Get(lockerNumber);
                        ConsoleIO.DisplayLockerContents(contents);
                    }
                    else if(choice == 2)
                    {
                        LockerContents contents = ConsoleIO.GetLockerContentsFromUser();
                        contents.LockerNumber = lockerNumber;
                        if (lockerStorage.Add(contents))
                        {
                            Console.WriteLine($"Locker {lockerNumber} is rented, stop by later to pick up your stuff!");
                        }
                        else
                        {
                            Console.WriteLine($"Sorry, but locker {lockerNumber} has already been rented!");
                        }                       
                    }
                    else
                    {
                        LockerContents contents = lockerStorage.Remove(lockerNumber);
                        if(contents == null)
                        {
                            Console.WriteLine($"Locker {lockerNumber} is not currently rented.");
                        }
                        else
                        {
                            Console.WriteLine($"Locker {lockerNumber} rental has ended, please take your {contents.Description}.");
                        }
                    }
                }

                ConsoleIO.AnyKey();
            }
        }
    }
}
