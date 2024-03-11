using CafePOS.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CafePOS.Data
{
    public class CafeContext : DbContext
    {
        public DbSet<Server> Server { get; set; }
        public DbSet<CafeOrder> CafeOrder { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemPrice> ItemPrice { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<TimeOfDay> TimeOfDay { get; set; }

        private string _connectionString;

        public CafeContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
