using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Application;
using CafePOS.Core.Interfaces.Repositories;
using CafePOS.Core.Interfaces.Services;

namespace CafePOS.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly int _timeOfDay;

        public OrderService(IOrderRepository orderRepository, ITimeOfDaySetting timeOfDay)
        {
            _orderRepository = orderRepository;
            _timeOfDay = timeOfDay.GetTimeOfDaySetting();
        }
        
        public Result<List<Category>> GetCategories()
        {
            try
            {
                var categories = _orderRepository.GetCategories(_timeOfDay);

                if (categories.Count() == 0)
                {
                    return ResultFactory.Fail<List<Category>>("Error getting category list.");
                }
                return ResultFactory.Success(categories);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<List<Category>>(ex.Message);
            }
        }

        public Result<List<ItemPrice>> GetAvailableItems(int categoryId)
        {
            try
            {
                var items = _orderRepository.GetAvailableItemsByCategory(categoryId, _timeOfDay);
                if (items.Count() == 0)
                {
                    return ResultFactory.Fail<List<ItemPrice>>("No items are available for that category.");
                }
                return ResultFactory.Success(items);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<List<ItemPrice>>(ex.Message);
            }
        }

        public Result<int> GetItem(int categoryId, int itemId)
        {
            try
            {
                var itemPriceId = _orderRepository.GetItemPriceID(categoryId, itemId, _timeOfDay);
                if (itemPriceId == 0)
                {
                    return ResultFactory.Fail<int>("Item is not available or does not exist.");
                }
                return ResultFactory.Success(itemPriceId);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<int>(ex.Message);
            }
        }

        public Result AddItemsToOrder(List<ItemToAdd> request)
        {
            try
            {
                _orderRepository.AddItemsToOrder(request);
                return ResultFactory.Success();
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail(ex.Message);
            }
        }

        public Result<List<CafeOrder>> GetOpenOrders()
        {
            try
            {
                var orders = _orderRepository.GetOpenOrders();
                if (orders.Count == 0)
                {
                    return ResultFactory.Fail<List<CafeOrder>>("There are no orders open currently.");
                }
                return ResultFactory.Success(orders);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<List<CafeOrder>>(ex.Message);
            }
        }

        public Result<List<OrderItem>> GetOrderDetails(int orderId)
        {
            try
            {
                var isValid = _orderRepository.IsValidOrderNumber(orderId);
                var isOpen = _orderRepository.IsOrderOpen(orderId);
                var details = _orderRepository.GetOrderDetails(orderId);

                if (!isValid)
                {
                    return ResultFactory.Fail<List<OrderItem>>("That is not a valid order number.");
                }
                if (!isOpen && isValid)
                {
                    return ResultFactory.Fail<List<OrderItem>>("That is not an open order.");
                }

                return ResultFactory.Success(details);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<List<OrderItem>>(ex.Message);
            }
        }

        public Result<bool> IsValidOpenOrder(int orderId)
        {
            try
            {
                var isValid = _orderRepository.IsValidOrderNumber(orderId);
                var isOpen = _orderRepository.IsOrderOpen(orderId);

                if (!isValid)
                {
                    return ResultFactory.Fail<bool>("That is not a valid order number.");
                }

                if (!isOpen)
                {
                    return ResultFactory.Fail<bool>("That order is not open currently.");
                }
                else
                {
                    return ResultFactory.Success(isOpen);
                }
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<bool>(ex.Message);
            }
        }

        public Result CancelOrder(int orderId)
        {
            try
            {
                _orderRepository.CancelOrder(orderId);
                return ResultFactory.Success();
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail(ex.Message);
            }
        }
    }
}
