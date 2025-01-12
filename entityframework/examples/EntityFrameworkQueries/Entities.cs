using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkQueries
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public int ItemID { get; set; }
        public int CategoryID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }

        public Category Category { get; set; }
        public List<ItemPrice> ItemPrices { get; set; }
    }

    public class ItemPrice
    {
        public int ItemPriceID { get; set; }
        public int ItemID { get; set; }
        public int TimeOfDayID { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Item Item { get; set; }
        public TimeOfDay TimeOfDay { get; set; }
    }

    public class TimeOfDay
    {
        public int TimeOfDayID { get; set; }
        public string TimeOfDayName { get; set; }
    }

    public class CafeOrder
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem
    {
        public int OrderItemID { get; set; }
        [ForeignKey("CafeOrder")]
        public int OrderID { get; set; }

        public CafeOrder CafeOrder { get; set; }
    }

    public class Server
    {
        public int ServerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TermDate { get; set; }
    }

    public class CafeContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemPrice> ItemPrice { get; set; }
        public DbSet<CafeOrder> CafeOrder { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Server> Server { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost,1433;Database=FourthWallCafe;" + 
                "User Id=sa;Password=SQLR0ck$;TrustServerCertificate=true;");
        }
    }

    public class CategoryItemCount
    {
        public string CategoryName { get; set; }
        public int ItemCount { get; set; }
    }
}
