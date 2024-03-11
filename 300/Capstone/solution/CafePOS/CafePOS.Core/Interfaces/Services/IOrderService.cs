using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;

namespace CafePOS.Core.Interfaces.Services
{
    public interface IOrderService
    {
        Result<List<Category>> GetCategories();
        Result AddItemsToOrder(List<ItemToAdd> orderItems);
        Result<List<ItemPrice>> GetAvailableItems(int categoryId);
        Result<int> GetItem(int categoryId, int itemId);
        Result<List<CafeOrder>> GetOpenOrders();
        Result<List<OrderItem>> GetOrderDetails(int orderId);
        Result<bool> IsValidOpenOrder(int orderId);
        Result CancelOrder(int orderId);
    }
}
