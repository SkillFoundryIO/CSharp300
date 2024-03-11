using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;

namespace CafePOS.Core.Interfaces.Services
{
    public interface IPaymentService
    {
        Result<bool> OrderHasItems(int orderId);
        Result AddTipToOrder(int orderId, decimal tip);
        Result<CafeOrder> GetOrderSubtotals(int orderId);
        Result<List<PaymentType>> GetPaymentTypes();
        Result ProcessPayment(int orderId, int paymentType);
        Result<decimal> GetFinalTotal(int orderId);
        Result<bool> OrderIsUnder15items(int orderId);
    }
}
