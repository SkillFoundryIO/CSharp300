using AirportLockerRental.UI.Actions;
using AirportLockerRental.UI.DTOs;

namespace AirportLockerRental.UI.Workflows
{
    // we only need one App object, so making it static is appropriate
    public static class App
    {
        public static void Run()
        {
            // instantiate a locker manager to do the work
            LockerManager _lockerManager = new LockerManager();

            while (true)
            {
                int choice = ConsoleIO.GetMenuOption();

                if(choice == 5)
                {
                    return;
                }
                else if(choice == 4)
                {
                    _lockerManager.ListContents();
                }
                else
                {
                    // we need a locker number for these three choices
                    int lockerNumber = ConsoleIO.GetLockerNumber();

                    if(choice == 1)
                    {
                        LockerContents contents = _lockerManager.ViewLocker(lockerNumber);
                        ConsoleIO.DisplayLockerContents(contents, lockerNumber);
                    }
                    else if(choice == 2)
                    {
                        if(_lockerManager.CanRentLocker(lockerNumber))
                        {
                            LockerContents contents = ConsoleIO.GetLockerContentsFromUser();
                            if (_lockerManager.RentLocker(lockerNumber, contents))
                            {
                                Console.WriteLine($"Locker {lockerNumber} is rented, stop by later to pick up your stuff!");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Sorry, but locker {lockerNumber} has already been rented!");
                        }
                        
                    }
                    else
                    {
                        LockerContents contents = _lockerManager.EndRental(lockerNumber);
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
