using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.Tests.MockRepos.ReportRepo
{
    public class ReportsAvailable : IReportRepository
    {
        public Dictionary<string, decimal> GetSalesReportCategoriesByDay(DateTime salesDate)
        {
            return new Dictionary<string, decimal>()
            {
                { "Beverage", 1000 },
                { "Sandwich", 2000 },
                { "Sides", 200 },
                { "Desserts", 800 },
            };
        }

        public List<OrderItem> GetSalesReportItemsByDay(DateTime salesDate)
        {
            return new List<OrderItem>()
            {
                new OrderItem(),
                new OrderItem(),
                new OrderItem(),
                new OrderItem(),
                new OrderItem(),
                new OrderItem()
            };
        }
    }
}
