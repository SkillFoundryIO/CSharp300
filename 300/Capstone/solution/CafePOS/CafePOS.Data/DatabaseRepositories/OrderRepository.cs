using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CafePOS.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private CafeContext _dbContext;

        public OrderRepository(string connectionString)
        {
            _dbContext = new CafeContext(connectionString);
        }

        public List<Category> GetCategories(int timeOfDay)
        {
            return _dbContext.ItemPrice
                 .Where(ip => ip.TimeOfDayID == timeOfDay)
                 .Select(ip => ip.Item.Category)
                 .Distinct()
                 .ToList();
        }

        public List<ItemPrice> GetAvailableItemsByCategory(int categoryId, int timeOfDay)
        {
            return _dbContext.ItemPrice
                .Include(ip => ip.Item)
                .Where(
                    ip => ip.Item.CategoryID == categoryId &&
                    ip.StartDate <= DateTime.Today &&
                    ip.EndDate == null &&
                    ip.TimeOfDayID == timeOfDay)
                .ToList();
        }

        public int GetItemPriceID(int categoryId, int itemId, int timeOfDay)
        {
            var item = _dbContext.ItemPrice
                .Include(ip => ip.Item)
                .FirstOrDefault(
                ip => ip.ItemID == itemId &&
                ip.Item.CategoryID == categoryId &&
                ip.StartDate < DateTime.Today &&
                ip.EndDate == null &&
                ip.TimeOfDayID == timeOfDay);
            return item == null ? 0 : item.ItemPriceID;
        }

        public void AddItemsToOrder(List<ItemToAdd> orderItems)
        {
            foreach (var oi in orderItems)
            {
                var eachPrice = _dbContext.ItemPrice.FirstOrDefault(ip => ip.ItemPriceID == oi.ItemPriceId).Price;

                OrderItem newItem = new OrderItem
                {
                    OrderID = oi.OrderId,
                    Quantity = (byte)oi.ItemQty,
                    ItemPriceID = oi.ItemPriceId,
                    ExtendedPrice = eachPrice * oi.ItemQty
                };
                _dbContext.OrderItem.Add(newItem);
            }

            _dbContext.SaveChanges();
        }

        public List<CafeOrder> GetOpenOrders()
        {
            return _dbContext.CafeOrder
                .Include(co => co.Server)
                .Where(co => co.PaymentTypeID == null)
                .ToList();
        }

        public List<OrderItem> GetOrderDetails(int orderId)
        {
            return _dbContext.OrderItem
                .Include(oi => oi.ItemPrice.Item)
                .Where(oi => oi.OrderID == orderId)
                .ToList();
        }

        public bool IsOrderOpen(int orderId)
        {
            return _dbContext.CafeOrder.FirstOrDefault(co => co.OrderID == orderId && co.PaymentTypeID == null) != null ? true : false;
        }

        public bool IsValidOrderNumber(int orderId)
        {
            return _dbContext.CafeOrder.FirstOrDefault(co => co.OrderID == orderId) != null ? true : false;
        }

        public void CancelOrder(int orderId)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                _dbContext.OrderItem.Where(oi => oi.OrderID == orderId).ExecuteDelete();

                _dbContext.CafeOrder.Where(co => co.OrderID == orderId).ExecuteDelete();

                transaction.Commit();
            }
        }
    }
}
