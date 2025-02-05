using AirportLockerSQLite.Actions;
using AirportLockerSQLite.Db;
using AirportLockerSQLite.Entities;

namespace AirportLockerSQLite.Workflows;

public static class RentLocker
{
    public static void Execute(LockerDbContext context, User user, Settings settings)
    {
        try
        {
            var lockerNumber = ConsoleIO.GetLockerNumber(settings.LockerCapacity);

            if (context.Rentals.Any(r => r.LockerNumber == lockerNumber))
            {
                Console.WriteLine("That locker is not available.");
                ConsoleIO.AnyKey();
                return;
            }

            string contents = ConsoleIO.GetRequiredString("Enter the locker contents: ");
            var em = new EncryptionManager(settings.PassPhrase);

            var rental = new Rental()
            {
                LockerNumber = lockerNumber,
                UserID = user.UserID,
                Contents = em.Encrypt(contents),
                StartDate = DateTime.UtcNow
            };

            context.Rentals.Add(rental);
            context.SaveChanges();
            Console.WriteLine("Locker Rental Successful!");
            ConsoleIO.AnyKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            ConsoleIO.AnyKey();
        }
    }
}
