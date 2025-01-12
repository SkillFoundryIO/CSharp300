using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.Tests.Mocks.PaymentRepo
{
    public class OrderHasOver15Items : IPaymentRepository
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
            return new List<PaymentType>()
            {
                new PaymentType(),
                new PaymentType()
            };
        }

        public bool IsOrderUnder15Items(int orderId)
        {
            return false;
        }

        public bool IsValidPaymentType(int paymentType)
        {
            return true;
        }

        public bool OrderHasItems(int orderId)
        {
            throw new NotImplementedException();
        }

        public void ProcessPayment(int orderId, int paymentType)
        {
            return;
        }
    }
}
