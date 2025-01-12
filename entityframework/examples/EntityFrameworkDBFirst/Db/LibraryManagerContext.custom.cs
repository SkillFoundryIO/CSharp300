using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDBFirst.Db;

public partial class LibraryManagerContext
{
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        // Add custom model configurations here
        modelBuilder.Entity<Borrower>();
    }
}