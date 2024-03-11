using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.Tests.MockRepos.ReportRepo
{
    public class NoReportsAvailable : IReportRepository
    {
        public Dictionary<string, decimal> GetSalesReportCategoriesByDay(DateTime salesDate)
        {
            return new Dictionary<string, decimal>();
        }

        public List<OrderItem> GetSalesReportItemsByDay(DateTime salesDate)
        {
            return new List<OrderItem>();
        }
    }
}
