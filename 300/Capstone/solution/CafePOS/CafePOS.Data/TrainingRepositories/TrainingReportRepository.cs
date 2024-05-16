using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.Data.TrainingRepositories
{
    public class TrainingReportRepository : IReportRepository
    {
        public Dictionary<string, decimal> GetSalesReportCategoriesByDay(DateTime salesDate)
        {
            var orders = FakeDb.CafeOrders
                .Where(co => co.OrderDate >= salesDate.Date && co.OrderDate < salesDate.Date.AddDays(1))
                .ToList();
            
            var orderIds = FakeDb.CafeOrders
                .Where(co => co.OrderDate >= salesDate.Date && co.OrderDate < salesDate.Date.AddDays(1))
                .Select(o => o.OrderID)
                .ToList();

            var data = new List<OrderItem>();

            foreach (var id in orderIds.ToList())
            {
                foreach (var order in orders.ToList())
                {
                    if (order.OrderID == id)
                    {
                        var orderDetails = FakeDb.OrderItems
                            .Where(oi => oi.OrderID == order.OrderID)
                            .ToList();

                        foreach (var detail in orderDetails)
                        {
                            if (detail.OrderID == order.OrderID)
                            {
                                detail.CafeOrder = order;
                                data.Add(detail);
                            }
                        }
                    }
                }
            }

            foreach (var d in data)
            {
                var price = FakeDb.ItemPrices
                    .First(ip => ip.ItemPriceID == d.ItemPriceID);
                
                d.ItemPrice = price;

                var name = FakeDb.Items
                    .First(i => i.ItemID == d.ItemPrice.ItemID);
                
                d.ItemPrice.Item = name;

                var category = FakeDb.Categories
                    .First(c => c.CategoryID == d.ItemPrice.Item.CategoryID);
                
                d.ItemPrice.Item.Category = category;
            }

            var report = data
                .GroupBy(d => d.ItemPrice.Item.Category.CategoryName)
                .Select(c => new { categoryName = c.Key, totalSales = c.Sum(c => c.ExtendedPrice) })
                .ToDictionary(c => c.categoryName, c => c.totalSales);

            return report;

        }

        public List<OrderItem> GetSalesReportItemsByDay(DateTime salesDate)
        {
            var report = new List<OrderItem>();

            var orders = FakeDb.CafeOrders
                .Where(co => co.OrderDate >= salesDate.Date && co.OrderDate < salesDate.Date.AddDays(1))
                .ToList();
            
            var orderIds = FakeDb.CafeOrders
                .Where(co => co.OrderDate >= salesDate.Date && co.OrderDate < salesDate.Date.AddDays(1))
                .Select(o => o.OrderID)
                .ToList();

            foreach (var id in orderIds.ToList())
            {
                foreach (var order in orders.ToList())
                {
                    if (order.OrderID == id)
                    {
                        var orderDetails = FakeDb.OrderItems
                            .Where(oi => oi.OrderID == order.OrderID)
                            .ToList();
                        
                        foreach (var detail in orderDetails)
                        {
                            if (detail.OrderID == order.OrderID)
                            {
                                detail.CafeOrder = order;
                                report.Add(detail);
                            }
                        }
                    }
                }
            }

            foreach (var r in report)
            {
                var price = FakeDb.ItemPrices
                    .First(ip => ip.ItemPriceID == r.ItemPriceID);
                
                r.ItemPrice = price;

                var name = FakeDb.Items
                    .First(i => i.ItemID == r.ItemPrice.ItemID);
                
                r.ItemPrice.Item = name;
            }

            return report;
        }
    }
}
