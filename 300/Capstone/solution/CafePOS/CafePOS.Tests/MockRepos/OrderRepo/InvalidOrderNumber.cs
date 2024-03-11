using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.Tests.Mocks.OrderRepo
{
    public class InvalidOrderNumber : IOrderRepository
    {
        public void AddItemsToOrder(List<ItemToAdd> orderItems)
        {
            throw new NotImplementedException();
        }

        public List<ItemPrice> GetAvailableItemsByCategory(int categoryId, int timeOfDay)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories(int timeOfDay)
        {
            throw new NotImplementedException();
        }

        public int GetItemPriceID(int categoryId, int itemId, int timeOfDay)
        {
            throw new NotImplementedException();
        }

        public List<CafeOrder> GetOpenOrders()
        {
            throw new NotImplementedException();
        }

        public List<OrderItem> GetOrderDetails(int orderId)
        {
            throw new NotImplementedException();
        }

        public bool IsOrderOpen(int orderId)
        {
            return false;
        }

        public bool IsValidOrderNumber(int orderId)
        {
            return false;
        }

        public void CancelOrder(int orderId)
        {
            return;
        }
    }
}
