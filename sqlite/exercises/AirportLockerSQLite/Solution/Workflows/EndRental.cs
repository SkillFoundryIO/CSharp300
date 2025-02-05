using AirportLockerSQLite.Actions;
using AirportLockerSQLite.Db;
using AirportLockerSQLite.Entities;

namespace AirportLockerSQLite.Workflows;

public class EndRental
{
    public static void Execute(LockerDbContext context, User user)
    {
        try
        {
            ConsoleIO.PrintHeading("End a Locker Rental");
            var rentedNumbers = context.Rentals.Where(r => r.UserID == user.UserID)
                .Select(r => r.LockerNumber);

            if (rentedNumbers.Any())
            {
                var lockerNumber = ConsoleIO.GetLockerNumberFromList(rentedNumbers);

                var rental = context.Rentals.First(r => r.LockerNumber == lockerNumber);

                var history = new RentalHistory()
                {
                    Contents = rental.Contents,
                    LockerNumber = rental.LockerNumber,
                    UserID = rental.UserID,
                    StartDate = rental.StartDate,
                    EndDate = DateTime.UtcNow
                };

                context.Rentals.Remove(rental);
                context.RentalHistory.Add(history);

                context.SaveChanges();

                Console.WriteLine("Rental ended!");
                ConsoleIO.AnyKey();
            }
            else
            {
                Console.WriteLine("You have no rentals.");
                ConsoleIO.AnyKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            ConsoleIO.AnyKey();
        }
    }
}
