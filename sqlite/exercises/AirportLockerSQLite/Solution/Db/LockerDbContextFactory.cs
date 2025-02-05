using Microsoft.EntityFrameworkCore;

namespace AirportLockerSQLite.Db;

public class LockerDbContextFactory
{
    public static LockerDbContext CreateDbContext(string connectionString)
    {
        // Instead of overriding in the DbContext we can extract the options settings
        var options = new DbContextOptionsBuilder<LockerDbContext>()
            .UseSqlite(connectionString)
            .Options;

        // We set up a DbContext constructor to provide the options.
        return new LockerDbContext(options);
    }
}
