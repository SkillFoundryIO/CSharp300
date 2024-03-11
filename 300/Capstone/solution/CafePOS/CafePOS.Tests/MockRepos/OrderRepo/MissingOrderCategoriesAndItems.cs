using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.Tests.Mocks.OrderRepo
{
    public class MissingOrderCategoriesAndItems : IOrderRepository
    {
        public void AddItemsToOrder(List<ItemToAdd> orderItems)
        {
            throw new NotImplementedException();
        }

        public List<ItemPrice> GetAvailableItemsByCategory(int categoryId, int timeOfDay)
        {
            return new List<ItemPrice>();
        }

        public List<Category> GetCategories(int timeOfDay)
        {
            return new List<Category>();
        }

        public int GetItemPriceID(int categoryId, int itemId, int timeOfDay)
        {
            return 0;
        }

        public List<CafeOrder> GetOpenOrders()
        {
            throw new NotImplementedException();
        }

        public List<OrderItem> GetOrderDetails(int orderId)
        {
            return new List<OrderItem>();
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
