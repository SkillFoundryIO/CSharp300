using CafePOS.Core.DTOs;
using CafePOS.Core.Interfaces.Services;

namespace CafePOS.ConsoleUI.IO
{
    public class OpenOrderWorkflow
    {
        public static void AddItemsToOrder(IOrderService service)
        {
            List<ItemToAdd> itemsAddedToOrder = new List<ItemToAdd>();

            bool haveOpenOrders = ListOpenOrders(service, false, "Add Items to Open Order");
            if (!haveOpenOrders)
            {
                Utilities.AnyKey();
                return;
            }

            int orderSelected = SelectOpenOrder(service);

            do
            {
                Utilities.DisplayMenuHeader("Add Items to Open Order");

                int categoryId = ListandSelectCategory(service);
               
                GetAvailableItemsByCategory(service, categoryId);

                ItemToAdd orderedItem = new ItemToAdd();

                int itemSelection = Utilities.GetPositiveInteger("\nSelect the item being added to the order: ");
                var itemResult = service.GetItem(categoryId, itemSelection);

                if (itemResult.Ok)
                {
                    orderedItem.OrderId = orderSelected;
                    orderedItem.ItemPriceId = itemResult.Data;
                    orderedItem.ItemQty = (byte)Utilities.GetIntZeroOrHigher("Enter quantity (or 0 to cancel): ");

                    if (orderedItem.ItemQty != 0)
                    {
                        itemsAddedToOrder.Add(orderedItem);
                    }
                }
                else
                {
                    Utilities.SystemMessageRed(itemResult.Message);
                }

                if (!Utilities.AddMoreItems())
                {
                    break;
                }

            } while (true);

            var addItemResult = service.AddItemsToOrder(itemsAddedToOrder);

            if (addItemResult.Ok)
            {
                ListOrderDetails(service, orderSelected);
            }
            else
            {
                Utilities.SystemMessageRed(addItemResult.Message);
            }
            Utilities.AnyKey();
        }

        public static void GetAvailableItemsByCategory(IOrderService service, int categoryId)
        {
            var listResult = service.GetAvailableItems(categoryId);

            if (listResult.Ok)
            {
                Console.Clear();
                Console.WriteLine("Available Items: ");
                Console.WriteLine($"{"Item ID",-10} {"Item Name",-30} {"Price",-5}");
                Console.WriteLine(new string('-', 50));

                foreach (var item in listResult.Data)
                {
                    Console.WriteLine($"{item.ItemID,-10} {item.Item.ItemName,-30} {item.Price,-5:c}");
                }
            }
            else
            {
                Utilities.SystemMessageRed(listResult.Message);
            }
        }

        public static bool ListOpenOrders(IOrderService service, bool viewDetails, string title)
        {
            Utilities.DisplayMenuHeader(title);

            var list = service.GetOpenOrders();
            if (list.Ok)
            {
                Console.WriteLine($"{"Order ID",-10}  {"Order Date",-15}  {"Server Name",-20}");
                Console.WriteLine(new string('-', 55));

                foreach (var order in list.Data)
                {
                    Console.WriteLine($"{order.OrderID,-10}  {order.OrderDate,-15:d}  {order.Server.FirstName + "  " + order.Server.LastName,-20}");
                }

                if (viewDetails)
                {
                    Console.WriteLine();
                    var input = Utilities.GetIntZeroOrHigher("Enter Order ID to view order details (or 0 to Quit): ");
                    if (input == 0)
                    {
                        return false;
                    }
                    ListOrderDetails(service, input);
                }
            }
            else
            {
                Utilities.SystemMessageRed(list.Message);
                return false;
            }
            return true;
        }

        public static int SelectOpenOrder(IOrderService service)
        {
            do
            {
                var input = Utilities.GetPositiveInteger("\nEnter Order ID: ");
                var isOpenResult = service.IsValidOpenOrder(input);

                if (isOpenResult.Ok)
                {
                    return input;
                }
                else
                {
                    Utilities.SystemMessageRed(isOpenResult.Message);
                }
            } while (true);
        }

        public static int ListandSelectCategory(IOrderService service)
        {
            Console.Clear();
            var categories = service.GetCategories();
            if (categories.Ok)
            {
                Console.WriteLine($"{"ID",-5} {"Category Name",-20}");
                Console.WriteLine(new string('-', 30));

                foreach (var category in categories.Data)
                {
                    Console.WriteLine($"{category.CategoryID,-5} {category.CategoryName,-20}");
                }
            }
            else
            {
                Utilities.SystemMessageRed(categories.Message);
            }

            return Utilities.GetPositiveInteger("\nEnter Category ID: ");

        }

        public static void ListOrderDetails(IOrderService service, int orderId)
        {
            var details = service.GetOrderDetails(orderId);

            if (details.Ok)
            {
                Utilities.DisplayMenuHeader($"Order Details");

                Console.WriteLine($"Order Details for Order {orderId}:\n");
                Console.WriteLine($"{"Item Name",-20} {"Qty",-5} {"Extended Price",-8}");

                Console.WriteLine(new string('-', 50));

                foreach (var d in details.Data)
                {
                    Console.WriteLine($"{d.ItemPrice.Item.ItemName,-20} {d.Quantity,-5} {d.ExtendedPrice,-8:c}");
                }
            }
            else
            {
                Utilities.SystemMessageRed(details.Message);
            }
        }
    }
}
