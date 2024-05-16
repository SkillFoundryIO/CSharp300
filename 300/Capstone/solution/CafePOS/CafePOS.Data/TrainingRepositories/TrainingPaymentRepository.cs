using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.Data.TrainingRepositories
{
    public class TrainingPaymentRepository : IPaymentRepository
    {
        public void AddTipToOrder(int orderId, decimal tip)
        {
            FakeDb.CafeOrders.FirstOrDefault(co => co.OrderID == orderId).Tip = tip;
        }

        public decimal GetFinalTotal(int orderId)
        {
            return (decimal)FakeDb.CafeOrders.FirstOrDefault(co => co.OrderID == orderId).AmountDue;
        }

        public CafeOrder GetOrderSubtotals(int orderId)
        {
            var order = FakeDb.CafeOrders.FirstOrDefault(co => co.OrderID == orderId && co.PaymentTypeID == null);
            var orderIndex = FakeDb.CafeOrders.IndexOf(order);

            var orderItems = FakeDb.OrderItems.Where(ci => ci.OrderID == orderId).ToList();

            if (orderItems.Count > 0)
            {
                order.SubTotal = orderItems.Sum(oi => oi.ExtendedPrice);
                order.Tax = order.SubTotal * .05M;
                order.AmountDue = order.SubTotal + order.Tax;
            }

            FakeDb.CafeOrders[orderIndex] = order;

            return order;
        }

        public List<PaymentType> GetPaymentTypes()
        {
            return FakeDb.PaymentTypes.ToList();
        }

        public bool IsOrderUnder15Items(int orderId)
        {
            return FakeDb.OrderItems.Where(oi => oi.OrderID == orderId).Sum(oi => oi.Quantity) < 15 ? true : false;
        }

        public bool IsValidPaymentType(int paymentType)
        {
            return FakeDb.PaymentTypes.FirstOrDefault(pt => pt.PaymentTypeID == paymentType) != null ? true : false;
        }

        public bool OrderHasItems(int orderId)
        {
            return FakeDb.OrderItems.Any(oi => oi.OrderID == orderId) ? true : false;
        }

        public void ProcessPayment(int orderId, int paymentType)
        {
            var order = FakeDb.CafeOrders.FirstOrDefault(co => co.OrderID == orderId);
            var orderIndex = FakeDb.CafeOrders.IndexOf(order);

            order.PaymentTypeID = paymentType;
            order.AmountDue = order.SubTotal + order.Tax + order.Tip;

            FakeDb.CafeOrders[orderIndex] = order;
        }
    }
}
