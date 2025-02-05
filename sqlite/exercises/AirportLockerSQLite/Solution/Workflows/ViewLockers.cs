using AirportLockerSQLite.Actions;
using AirportLockerSQLite.Db;
using AirportLockerSQLite.Entities;

namespace AirportLockerSQLite.Workflows;

public static class ViewLockers
{
    public static void Execute(LockerDbContext context, User user, Settings settings)
    {
        try
        {
            ConsoleIO.PrintHeading("View Rented Lockers");

            var rentals = context.Rentals
                .Where(r => r.UserID == user.UserID)
                .OrderBy(r => r.LockerNumber);

            if (rentals.Any())
            {
                var em = new EncryptionManager(settings.PassPhrase);

                foreach(var rental in rentals)
                {
                    Console.WriteLine("==========================================");
                    Console.WriteLine($"Locker #: {rental.LockerNumber}");
                    Console.WriteLine($"Start Date: {rental.StartDate.ToLocalTime().ToLongDateString()}");
                    Console.WriteLine($"Contents: {em.Decrypt(rental.Contents)}");
                    Console.WriteLine("==========================================\n");
                }
            }
            else
            {
                Console.WriteLine("You have no active rentals.");
            }

            ConsoleIO.AnyKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            ConsoleIO.AnyKey();
        }

    }
}
