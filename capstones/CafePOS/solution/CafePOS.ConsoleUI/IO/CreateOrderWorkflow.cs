using CafePOS.Core.Interfaces.Services;

namespace CafePOS.ConsoleUI.IO
{
    public class CreateOrderWorkflow
    {
        public static void GetServerList(INewOrderService service)
        {
            var serverList = service.GetServerList();

            Console.WriteLine("Available Server List");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"  {"ID #",-10} {"Name",-30}");
            Console.WriteLine(new string('-', 40));

            if (serverList.Ok)
            {
                foreach (var server in serverList.Data)
                {
                    Console.WriteLine($"  {server.ServerID,-10} {server.FirstName + " " + server.LastName,-30}");
                }
            }
            else
            {
                Utilities.SystemMessageRed(serverList.Message);
            }
        }

        public static void CreateNewOrder(INewOrderService service)
        {
            Utilities.DisplayMenuHeader("Create New Order");

            GetServerList(service);

            int serverID = Utilities.GetPositiveInteger("\nSelect ID# of server: ");

            var serverResult = service.GetServer(serverID);

            if (serverResult.Ok)
            {
                var orderResult = service.CreateNewOrder(serverResult.Data);

                if (orderResult.Ok)
                {
                    Utilities.SystemMessageGreen($"\nA new order with #{orderResult.Data} " +
                        $"has been created and assigned to server " +
                        $"{serverResult.Data.FirstName + " " + serverResult.Data.LastName}.");
                }
                else
                {
                    Utilities.SystemMessageRed(orderResult.Message);
                }
            }
            else
            {
                Utilities.SystemMessageRed(serverResult.Message);
            }
            Utilities.AnyKey();
        }
    }
}
