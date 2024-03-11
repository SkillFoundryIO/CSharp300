using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;

namespace CafePOS.Core.Interfaces.Services
{
    public interface IReportService
    {
        Result<List<OrderItem>> GetSalesReportItemsByDay(DateTime salesDate);
        Result<Dictionary<string, decimal>> GetSalesReportCategoriesByDay(DateTime salesDate);
    }
}
