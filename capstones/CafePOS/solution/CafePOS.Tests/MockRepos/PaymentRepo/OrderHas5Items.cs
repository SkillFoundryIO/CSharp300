using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.Tests.Mocks.PaymentRepo
{
    public class OrderHas5Items : IPaymentRepository
    {
        public void AddTipToOrder(int orderId, decimal tip)
        {
            return;
        }

        public decimal GetFinalTotal(int orderId)
        {
            return 50;
        }

        public CafeOrder GetOrderSubtotals(int orderId)
        {
            return new CafeOrder
            {
                SubTotal = 25,
                Tax = 4,
                Tip = 5,
            };
        }

        public List<PaymentType> GetPaymentTypes()
        {
            throw new NotImplementedException();
        }

        public bool IsOrderUnder15Items(int orderId)
        {
            return true;
        }

        public bool IsValidPaymentType(int paymentType)
        {
            throw new NotImplementedException();
        }

        public bool OrderHasItems(int orderId)
        {
            return true;
        }

        public void ProcessPayment(int orderId, int paymentType)
        {
            throw new NotImplementedException();
        }
    }
}
