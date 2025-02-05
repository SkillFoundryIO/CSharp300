using AirportLockerSQLite.Actions;
using AirportLockerSQLite.Db;
using AirportLockerSQLite.Entities;

namespace AirportLockerSQLite.Workflows;

public static class CreateAccount
{
    public static void Execute(LockerDbContext context)
    {
        ConsoleIO.PrintHeading("Create New Account");

        try
        {
            HashManager hm = new();
            byte[] salt;
            User newUser = new();

            newUser.UserName = GetUserName(context);
            salt = hm.CreateSalt();
            newUser.Salt = Convert.ToHexString(salt);
            newUser.PasswordHash = hm.HashPassword(ConsoleIO.GetRequiredString("Enter password: "), salt);

            context.Users.Add(newUser);
            context.SaveChanges();

            Console.WriteLine($"User created: {newUser.UserName} with ID {newUser.UserID}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        ConsoleIO.AnyKey();
    }

    private static string GetUserName(LockerDbContext context)
    {
        do
        {
            string userName = ConsoleIO.GetRequiredString("Enter user name: ");

            // is user name available?
            if(context.Users.Any(u=>u.UserName == userName))
            {
                Console.WriteLine("That user name is not available!");
            }
            else
            {
                return userName;
            }
        } while (true);
    }
}
