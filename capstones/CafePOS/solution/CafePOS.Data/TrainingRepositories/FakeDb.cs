using CafePOS.Core.Entities;

namespace CafePOS.Data.TrainingRepositories
{
    public class FakeDb
    {
        public static List<CafeOrder> CafeOrders = new List<CafeOrder>
        {
            new CafeOrder{OrderID = 1, ServerID = 1, OrderDate = new DateTime(2024,1,4), PaymentTypeID = 2, SubTotal = 85M, Tax = 4.25M, Tip = 13.50M, AmountDue = 102.75M },
            new CafeOrder{OrderID = 2, ServerID = 2, OrderDate = new DateTime(2024,1,4), PaymentTypeID = 1, SubTotal = 10M, Tax = 0.5M, Tip = 2M, AmountDue = 12.5M },
            new CafeOrder{OrderID = 3, ServerID = 1, OrderDate = new DateTime(2024,1,4), PaymentTypeID = 2, SubTotal = 16M, Tax = 0.8M, Tip = 5M, AmountDue = 21.80M },
            new CafeOrder{OrderID = 4, ServerID = 2, OrderDate = new DateTime(2024,1,4), PaymentTypeID = 1, SubTotal = 9M, Tax = 0.45M, Tip = 2M, AmountDue = 11.45M },
            new CafeOrder{OrderID = 5, ServerID = 1, OrderDate = new DateTime(2024,1,5), PaymentTypeID = null },
            new CafeOrder{OrderID = 6, ServerID = 2, OrderDate = new DateTime(2024,1,7), PaymentTypeID = null }
        };

        public static List<Server> Servers = new List<Server>
        {
            new Server{ServerID = 1, FirstName = "John", LastName = "Smith" },
            new Server{ServerID = 2, FirstName = "Sarah", LastName = "Johnson" }
        };

        public static List<ItemPrice> ItemPrices = new List<ItemPrice>
        {
            new ItemPrice{ItemPriceID = 1, Price = 3.00M, ItemID = 1 },
            new ItemPrice{ItemPriceID = 2, Price = 10.00M, ItemID = 2 },
            new ItemPrice{ItemPriceID = 3, Price = 5.00M, ItemID = 3 },
            new ItemPrice{ItemPriceID = 4, Price = 8.00M, ItemID = 4 },
            new ItemPrice{ItemPriceID = 5, Price = 2.50M, ItemID = 5 },
            new ItemPrice{ItemPriceID = 6, Price = 4.00M, ItemID = 6 },
            new ItemPrice{ItemPriceID = 7, Price = 5.00M, ItemID = 7 },

        };

        public static List<OrderItem> OrderItems = new List<OrderItem>
        {
            new OrderItem {OrderItemID = 1, OrderID = 1, ItemPriceID = 1, Quantity = 5, ExtendedPrice = 15M},
            new OrderItem {OrderItemID = 2, OrderID = 1, ItemPriceID = 2, Quantity = 5, ExtendedPrice = 50M},
            new OrderItem {OrderItemID = 3, OrderID = 1, ItemPriceID = 3, Quantity = 5, ExtendedPrice = 25M},
            new OrderItem {OrderItemID = 4, OrderID = 2, ItemPriceID = 7, Quantity = 2, ExtendedPrice = 10M},
            new OrderItem {OrderItemID = 5, OrderID = 3, ItemPriceID = 4, Quantity = 2, ExtendedPrice = 16M},
            new OrderItem {OrderItemID = 6, OrderID = 4, ItemPriceID = 1, Quantity = 3, ExtendedPrice = 9M},
            new OrderItem {OrderItemID = 7, OrderID = 5, ItemPriceID = 4, Quantity = 4, ExtendedPrice = 16M}

        };

        public static List<Item> Items = new List<Item>
        {
            new Item {ItemID = 1, CategoryID = 1, ItemName = "Coffee" },
            new Item {ItemID = 2, CategoryID = 1, ItemName = "Wine" },
            new Item {ItemID = 3, CategoryID = 2, ItemName = "Reuben" },
            new Item {ItemID = 4, CategoryID = 2, ItemName = "BLT" },
            new Item {ItemID = 5, CategoryID = 3, ItemName = "Fries" },
            new Item {ItemID = 6, CategoryID = 3, ItemName = "Chips" },
            new Item {ItemID = 7, CategoryID = 4, ItemName = "Cake" }

        };

        public static List<Category> Categories = new List<Category>
        {
            new Category {CategoryID = 1, CategoryName = "Beverage" },
            new Category {CategoryID = 2, CategoryName = "Sandwich" },
            new Category {CategoryID = 3, CategoryName = "Sides" },
            new Category {CategoryID = 4, CategoryName = "Desserts" }
        };

        public static List<PaymentType> PaymentTypes = new List<PaymentType>
        {
            new PaymentType {PaymentTypeID = 1, PaymentTypeName = "Cash"},
            new PaymentType {PaymentTypeID = 2, PaymentTypeName = "Visa"}
        };
    }
}    