using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.Data.TrainingRepositories
{
    public class TrainingOrderRepository : IOrderRepository
    {
        public void AddItemsToOrder(List<ItemToAdd> orderItems)
        {
            foreach (var oi in orderItems)
            {
                var eachPrice = FakeDb.ItemPrices.FirstOrDefault(ip => ip.ItemPriceID == oi.ItemPriceId).Price;

                OrderItem newItem = new OrderItem
                {
                    OrderID = oi.OrderId,
                    Quantity = (byte)oi.ItemQty,
                    ItemPriceID = oi.ItemPriceId,
                    ExtendedPrice = eachPrice * oi.ItemQty
                };
                FakeDb.OrderItems.Add(newItem);
            }
        }

        public List<ItemPrice> GetAvailableItemsByCategory(int categoryId, int timeOfDay)
        {

            var itemList = FakeDb.Items.Where(i => i.CategoryID == categoryId).ToList();
            var itemPriceList = FakeDb.ItemPrices;

            var itemPrice = new List<ItemPrice>();

            foreach (var price in itemPriceList)
            {
                foreach (var item in itemList) 
                {
                    if (price.ItemID == item.ItemID)
                    {
                        price.Item = item;
                        itemPrice.Add(price);
                    }
                }
            }

            return itemPrice;
        }

        public List<Category> GetCategories(int timeOfDay)
        {
            return FakeDb.Categories.ToList();
        }

        public int GetItemPriceID(int categoryId, int itemId, int timeOfDay)
        {
            var item = FakeDb.Items.Where(i => i.CategoryID == categoryId).ToList();
            var itemPrice = FakeDb.ItemPrices.Where(ip => ip.ItemID == itemId).ToList();

            if (item.Exists(i => i.ItemID == itemId))
            {
                return itemPrice.FirstOrDefault(ip => itemId == itemId).ItemPriceID;
            }
            else
            {
                return 0;
            }
            
        }

        public List<CafeOrder> GetOpenOrders()
        {
            var orders = FakeDb.CafeOrders.Where(co => co.PaymentTypeID == null).ToList();
            var servers = FakeDb.Servers;

            var openOrders = new List<CafeOrder>();

            foreach (var order in orders)
            {
                foreach (var server in servers)
                {
                    if (order.ServerID == server.ServerID)
                    {
                        Server name = new Server { FirstName = server.FirstName, LastName = server.LastName };

                        order.Server = name;

                        openOrders.Add(order);
                    }
                }
            }
            return openOrders;
        }

        public List<OrderItem> GetOrderDetails(int orderId)
        {
            var orderItemList = FakeDb.OrderItems.Where(oi => oi.OrderID == orderId).ToList();
            var itemList = FakeDb.Items;
            var orderDetails = new List<OrderItem>();

            foreach (var order in orderItemList)
            {
                var itemPriceId = order.ItemPriceID;
                var itemId = FakeDb.ItemPrices.FirstOrDefault(ip => ip.ItemPriceID == itemPriceId).ItemID;
                var item = FakeDb.Items.FirstOrDefault(i => i.ItemID == itemId);

                if (itemPriceId != null && itemId != null && item != null)
                {
                    var name = new ItemPrice { Item = new Item { ItemName = item.ItemName } };
                    order.ItemPrice = name;
                    orderDetails.Add(order);
                }
            }

            return orderDetails;
        }

        public bool IsOrderOpen(int orderId)
        {
            return FakeDb.CafeOrders.FirstOrDefault(co => co.OrderID == orderId && co.PaymentTypeID == null) != null ? true : false;
        }

        public bool IsValidOrderNumber(int orderId)
        {
            return FakeDb.CafeOrders.FirstOrDefault(co => co.OrderID == orderId) != null ? true : false;
        }

        public void CancelOrder(int orderId)
        {
            var orderDetailList = FakeDb.OrderItems;

            foreach (var detail in orderDetailList.ToList())
            {
                if (detail.OrderID == orderId)
                {
                    orderDetailList.Remove(detail);
                }
            }
            FakeDb.OrderItems = orderDetailList;

            var order = FakeDb.CafeOrders.First(co => co.OrderID == orderId);
            FakeDb.CafeOrders.Remove(order);

            var o = FakeDb.CafeOrders;
        }

    }
}
