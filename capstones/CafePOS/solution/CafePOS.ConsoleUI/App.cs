using CafePOS.Application;
using CafePOS.ConsoleUI.IO;

namespace CafePOS.ConsoleUI
{
    public class App
    {
        private AppConfiguration _config;
        private ServiceFactory _serviceFactory;

        public App()
        {
            _config = new AppConfiguration();
            _serviceFactory = new ServiceFactory(_config);
        }

        public void Run()
        {
            // runs the main menu loop
            do
            {
                Console.Clear();
                int choice = Menus.MainMenu();

                switch (choice)
                {
                    case 0:
                        return;
                    case 1:
                        CreateOrderWorkflow.CreateNewOrder(_serviceFactory.CreateNewOrderService());
                        break;
                    case 2:
                        OpenOrderWorkflow.AddItemsToOrder(_serviceFactory.CreateOrderService());
                        break;
                    case 3:
                        OpenOrderWorkflow.ListOpenOrders(_serviceFactory.CreateOrderService(), true, "View Open Orders");
                        Utilities.AnyKey();
                        break;
                    case 4:
                        CancelOrderWorkflow.CancelOrder(_serviceFactory.CreateOrderService());
                        break;
                    case 5:
                        PaymentWorkflow.ProcessPayment(_serviceFactory.CreatePaymentService(), _serviceFactory.CreateOrderService());
                        break;
                    case 6:
                        ReportWorkflow.GetSalesReportItemsByDay(_serviceFactory.CreateReportService());
                        break;
                    case 7:
                        ReportWorkflow.GetSalesReportCategoriesByDay(_serviceFactory.CreateReportService());
                        break;
                }
            } while (true);
        }
    }
}
