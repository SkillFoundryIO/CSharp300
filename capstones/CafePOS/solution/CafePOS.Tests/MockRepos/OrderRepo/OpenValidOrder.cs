using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.Tests.Mocks.OrderRepo
{
    public class OpenValidOrder : IOrderRepository
    {
        public void AddItemsToOrder(List<ItemToAdd> orderItems)
        {
            return;
        }

        public List<ItemPrice> GetAvailableItemsByCategory(int categoryId, int timeOfDay)
        {
            return new List<ItemPrice>
            {
                new ItemPrice()
            };
        }

        public List<Category> GetCategories(int timeOfDay)
        {
            return new List<Category>()
            {
                new Category(),
                new Category(),
                new Category()
            };
        }

        public int GetItemPriceID(int categoryId, int itemId, int timeOfDay)
        {
            return 5000;
        }

        public List<CafeOrder> GetOpenOrders()
        {
            return new List<CafeOrder> {
                new CafeOrder(),
                new CafeOrder()
            };
        }

        public List<OrderItem> GetOrderDetails(int orderId)
        {
            return new List<OrderItem>
            {
                new OrderItem(),
                new OrderItem()
            };
        }

        public bool IsOrderOpen(int orderId)
        {
            return true;
        }

        public bool IsValidOrderNumber(int orderId)
        {
            return true;
        }

        public void CancelOrder(int orderId)
        {
            return;
        }
    }
}
