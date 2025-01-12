using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;

namespace CafePOS.Core.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        void AddItemsToOrder(List<ItemToAdd> orderItems);
        List<ItemPrice> GetAvailableItemsByCategory(int categoryId, int timeOfDay);
        int GetItemPriceID(int categoryId, int itemId, int timeOfDay);
        List<Category> GetCategories(int timeOfDay);
        List<CafeOrder> GetOpenOrders();
        List<OrderItem> GetOrderDetails(int orderId);
        bool IsOrderOpen(int orderId);
        bool IsValidOrderNumber(int orderId);
        void CancelOrder(int orderId);
    }
}
