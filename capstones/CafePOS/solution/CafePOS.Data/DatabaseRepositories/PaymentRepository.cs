using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.Data.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private CafeContext _dbContext;

        public PaymentRepository(string connectionString)
        {
            _dbContext = new CafeContext(connectionString);
        }

        public bool OrderHasItems(int orderId)
        {
            return _dbContext.OrderItem
                .Any(oi => oi.OrderID == orderId) ? true : false;
        }

        public CafeOrder GetOrderSubtotals(int orderId)
        {
            var order = _dbContext.CafeOrder
                .FirstOrDefault(co => co.OrderID == orderId && co.PaymentTypeID == null);
            
            var orderItems = _dbContext.OrderItem
                .Where(ci => ci.OrderID == orderId)
                .ToList();

            if (orderItems.Count > 0)
            {
                order.SubTotal = orderItems.Sum(oi => oi.ExtendedPrice);
                order.Tax = order.SubTotal * .065M;
                order.AmountDue = order.SubTotal + order.Tax;
            }

            _dbContext.SaveChanges();

            return order;
        }

        public List<PaymentType> GetPaymentTypes()
        {
            return _dbContext.PaymentType.ToList();
        }

        public bool IsValidPaymentType(int paymentType)
        {
            return _dbContext.PaymentType
                .FirstOrDefault(pt => pt.PaymentTypeID == paymentType) != null ? true : false;
        }

        public void ProcessPayment(int orderId, int paymentType)
        {
            var order = _dbContext.CafeOrder
                .FirstOrDefault(co => co.OrderID == orderId);

            order.PaymentTypeID = paymentType;

            _dbContext.SaveChanges();
        }

        public void AddTipToOrder(int orderId, decimal tip)
        {
            var order = _dbContext.CafeOrder
                .FirstOrDefault(co => co.OrderID == orderId);

            order.Tip = tip;
            order.AmountDue = order.SubTotal + order.Tax + order.Tip;

            _dbContext.SaveChanges();
        }

        public decimal GetFinalTotal(int orderId)
        {
            return (decimal)_dbContext.CafeOrder
                .FirstOrDefault(co => co.OrderID == orderId).AmountDue;
        }

        public bool IsOrderUnder15Items(int orderId)
        {
            return _dbContext.OrderItem
                .Where(oi => oi.OrderID == orderId).Sum(oi => oi.Quantity) < 15 ? true : false;
        }
    }
}
