using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CafePOS.Data.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private CafeContext _dbContext;

        public ReportRepository(string connectionString)
        {
            _dbContext = new CafeContext(connectionString);
        }

        public Dictionary<string, decimal> GetSalesReportCategoriesByDay(DateTime salesDate)
        {
            var a = _dbContext.OrderItem
                .Include(oi => oi.CafeOrder)
                .Include(oi => oi.ItemPrice)
                    .ThenInclude(ip => ip.Item)
                    .ThenInclude(i => i.Category)
                .Where(oi => oi.CafeOrder.OrderDate >= salesDate &&
                    oi.CafeOrder.OrderDate < salesDate.Date.AddDays(1))
                .GroupBy(oi => oi.ItemPrice.Item.Category.CategoryName)
                .Select(c => new { categoryName = c.Key, totalSales = c.Sum(c => c.ExtendedPrice) })
                .ToDictionary(c => c.categoryName, c => c.totalSales);

            return a;
        }

        public List<OrderItem> GetSalesReportItemsByDay(DateTime salesDate)
        {
            return _dbContext.OrderItem
                .Include(oi => oi.CafeOrder)
                .Include(oi => oi.ItemPrice)
                .Include(oi => oi.ItemPrice.Item)
                .Where(oi => oi.CafeOrder.OrderDate >= salesDate.Date &&
                    oi.CafeOrder.OrderDate < salesDate.Date.AddDays(1))
                .ToList();
        }
    }
}
