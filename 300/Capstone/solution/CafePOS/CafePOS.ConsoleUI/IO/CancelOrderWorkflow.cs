using CafePOS.Core.Interfaces.Services;

namespace CafePOS.ConsoleUI.IO
{
    public class CancelOrderWorkflow
    {
        public static void ListOpenOrders(IOrderService service)
        {
            Utilities.DisplayMenuHeader("Cancel Order");

            var list = service.GetOpenOrders();
            if (list.Ok)
            {
                Console.WriteLine($"{"Order ID",-10}  {"Order Date",-15}  {"Server Name",-20}");
                Console.WriteLine(new string('-', 55));

                foreach (var order in list.Data)
                {
                    Console.WriteLine($"{order.OrderID,-10}  {order.OrderDate,-15:d}  {order.Server.FirstName + "  " + order.Server.LastName,-20}");
                }
            }
            else
            {
                Utilities.SystemMessageRed(list.Message);
            }
        }

 

        public static void CancelOrder(IOrderService service)
        {
            ListOpenOrders(service);

            var input = Utilities.GetIntZeroOrHigher("\nEnter Order ID (or 0 to Cancel): ");
            if (input == 0)
            {
                return;
            }

            var isOpenResult = service.IsValidOpenOrder(input);

            if (isOpenResult.Ok)
            {
                var cancelResult = service.CancelOrder(input);
                if (cancelResult.Ok)
                {
                    Utilities.SystemMessageGreen($"\nOrder# {input} has been cancelled.");
                }
                else
                {
                    Utilities.SystemMessageRed(cancelResult.Message);
                }
            }
            else
            {
                Utilities.SystemMessageRed(isOpenResult.Message);
            }

            Utilities.AnyKey();
        }
    }
}
