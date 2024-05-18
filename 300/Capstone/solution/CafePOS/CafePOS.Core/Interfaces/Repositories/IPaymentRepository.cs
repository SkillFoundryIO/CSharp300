using CafePOS.Core.Entities;

namespace CafePOS.Core.Interfaces.Repositories
{
    public interface IPaymentRepository
    {
        bool OrderHasItems(int orderId);
        void AddTipToOrder(int orderId, decimal tip);
        CafeOrder GetOrderSubtotals(int orderId);
        List<PaymentType> GetPaymentTypes();
        bool IsValidPaymentType(int paymentType);
        void ProcessPayment(int orderId, int paymentType);
        decimal GetFinalTotal(int orderId);
        bool IsOrderUnder15Items(int orderId);
    }
}
