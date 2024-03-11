using CafePOS.Core.Entities;

namespace CafePOS.Core.Interfaces.Repositories
{
    public interface IReportRepository
    {
        List<OrderItem> GetSalesReportItemsByDay(DateTime salesDate);

        Dictionary<string, decimal> GetSalesReportCategoriesByDay(DateTime salesDate);
    }
}
