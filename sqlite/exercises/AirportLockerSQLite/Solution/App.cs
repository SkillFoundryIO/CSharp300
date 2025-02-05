using AirportLockerSQLite.Actions;
using AirportLockerSQLite.Db;
using AirportLockerSQLite.Entities;
using AirportLockerSQLite.Workflows;

namespace AirportLockerSQLite;

public class App
{
    private readonly Settings _settings;
    private LockerDbContext _context;

    public App(Settings settings)
    {
        _settings = settings;
        _context = LockerDbContextFactory.CreateDbContext(_settings.ConnectionString);
    }

    public void Run()
    {
        do
        {
            Console.Clear();
            int choice = ConsoleIO.DisplayAccountMenu();

            switch (choice)
            {
                case 1:
                    var user = Login.Execute(_context);
                    AccessRentals(user);
                    break;
                case 2:
                    CreateAccount.Execute(_context);
                    break;
                case 3:
                    return;
            }
        } while (true);
    }

    private void AccessRentals(User? user)
    {
        if (user == null)
        {
            return;
        }

        do
        {
            int choice = ConsoleIO.DisplayLockerMenu(user);

            switch(choice)
            {
                case 1:
                    RentLocker.Execute(_context, user, _settings);
                    break;
                case 2:
                    EndRental.Execute(_context, user);
                    break;
                case 3:
                    ViewLockers.Execute(_context, user, _settings);
                    break;
                case 4:
                    return;
            }
        } while (true);

    }
}
