using AirportLockerSQLite.Actions;
using AirportLockerSQLite.Db;
using AirportLockerSQLite.Entities;
using System.Text;

namespace AirportLockerSQLite.Workflows;

public static class Login
{
    public static User? Execute(LockerDbContext context)
    {
        ConsoleIO.PrintHeading("Login");

        string username = ConsoleIO.GetRequiredString("Enter user name: ");
        string password = ConsoleIO.GetRequiredString("Enter password: ");

        var user = context.Users.FirstOrDefault(u => u.UserName == username);

        if(IsValidCredentials(user, password))
        {
            return user;
        }
        else
        {
            Console.WriteLine("Invalid login.");
            ConsoleIO.AnyKey();
            return null;
        }
    }

    private static bool IsValidCredentials(User? user, string password)
    {
        if (user == null)
        {
            return false;
        }

        byte[] salt = Convert.FromHexString(user.Salt);
        var hm = new HashManager();
        var hash = hm.HashPassword(password, salt);

        return user.PasswordHash == hash;
    }
}
