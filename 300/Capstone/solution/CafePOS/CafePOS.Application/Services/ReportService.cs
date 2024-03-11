using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;
using CafePOS.Core.Interfaces.Services;

namespace CafePOS.Application.Services
{
    public class ReportService : IReportService
    {
        private IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public Result<Dictionary<string, decimal>> GetSalesReportCategoriesByDay(DateTime salesDate)
        {
            try
            {
                var sales = _reportRepository.GetSalesReportCategoriesByDay(salesDate);

                if (sales.Count == 0)
                {
                    return ResultFactory.Fail<Dictionary<string, decimal>>($"No sales data for date {salesDate.Date:d}.");
                }
                return ResultFactory.Success(sales);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<Dictionary<string, decimal>>(ex.Message);
            }
        }

        public Result<List<OrderItem>> GetSalesReportItemsByDay(DateTime salesDate)
        {
            try
            {
                var sales = _reportRepository.GetSalesReportItemsByDay(salesDate);

                if (sales.Count == 0)
                {
                    return ResultFactory.Fail<List<OrderItem>>($"No sales data for date {salesDate.Date:d}.");
                }
                return ResultFactory.Success(sales);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<List<OrderItem>>(ex.Message);
            }
        }
    }
}
