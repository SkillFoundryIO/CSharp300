using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.Tests.Mocks.PaymentRepo
{
    public class SystemHasNoPaymentTypes : IPaymentRepository
    {
        public void AddTipToOrder(int orderId, decimal tip)
        {
            throw new NotImplementedException();
        }

        public decimal GetFinalTotal(int orderId)
        {
            throw new NotImplementedException();
        }

        public CafeOrder GetOrderSubtotals(int orderId)
        {
            throw new NotImplementedException();
        }

        public List<PaymentType> GetPaymentTypes()
        {
            return new List<PaymentType>();
        }

        public bool IsOrderUnder15Items(int orderId)
        {
            throw new NotImplementedException();
        }

        public bool IsValidPaymentType(int paymentType)
        {
            return false;
        }

        public bool OrderHasItems(int orderId)
        {
            return false;
        }

        public void ProcessPayment(int orderId, int paymentType)
        {
            return;
        }
    }
}
