using AirportLockerSQLite.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirportLockerSQLite.Db;

public class LockerDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<RentalHistory> RentalHistory { get; set; }

    // support both design-time and run-time because of migrations
    public LockerDbContext() : base() { }
    public LockerDbContext(DbContextOptions<LockerDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(e => e.UserID);
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.ToTable("Rentals");
            entity.HasKey(e => e.LockerNumber);
            entity.HasOne(e => e.User)
                .WithMany(u => u.Rentals)
                .HasForeignKey(e => e.UserID);
        });

        modelBuilder.Entity<RentalHistory>(entity =>
        {
            entity.ToTable("RentalHistory");
            entity.HasKey(e => e.RentalID);
            entity.HasOne(e => e.User)
                .WithMany(u => u.RentalHistory)
                .HasForeignKey(e => e.UserID);
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // if we pass the options object in the constructor, this will not be used
        // otherwise, it sets the data source so we can use migrations at design-time
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=lockers.db");
        }
    }
}