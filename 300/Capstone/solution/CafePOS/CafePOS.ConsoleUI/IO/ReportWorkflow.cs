using CafePOS.Core.Interfaces.Services;

namespace CafePOS.ConsoleUI.IO
{
    public class ReportWorkflow
    {
        public static void GetSalesReportItemsByDay(IReportService service)
        {
            Console.Clear();
            Utilities.DisplayMenuHeader("Sales Report: Orders & Items By Sales Date");

            DateTime date = Utilities.GetDate("Enter date (ex: 10/10/24): ");

            var report = service.GetSalesReportItemsByDay(date);

            if (report.Ok)
            {
                Console.Clear();
                Utilities.DisplayMenuHeader("Sales Report: Orders & Items By Sales Date");

                Utilities.SystemMessageGreen($"Sales Report for: {date.Date:d}:\n");

                Console.WriteLine(new string('-', 100));
                Console.WriteLine($"{"Date",-12} {"Order ID",-10} {"Item name",-30} {"Qty",-10} {"Price",-10} {"Item Total",-15}");
                Console.WriteLine(new string('-', 100));

                int orderId = 0;
                decimal tax = 0;
                decimal tip = 0;
                decimal orderTotal = 0;

                foreach (var r in report.Data)
                {
                    if (orderId != r.OrderID && orderId != 0)
                    {
                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine($"{"",-63} {"Tax ",12} {tax,-15:c}");
                        Console.WriteLine($"{"",-63} {"Tip ",12} {tip,-15:c}");
                        Utilities.SystemMessageGreen($"{"",-63} {"Order Total ",12} {orderTotal,-15:c}\n");

                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine($"{"Date",-12} {"Order ID",-10} {"Item name",-30} {"Qty",-10} {"Price",-10} {"Item Total",-15}");
                        Console.WriteLine(new string('-', 100));
                    }

                    Console.WriteLine($"{r.CafeOrder.OrderDate,-12:d} {r.OrderID,-10} {r.ItemPrice.Item.ItemName,-30:c} {r.Quantity,-10} {r.ItemPrice.Price,-10:c} {r.ExtendedPrice,-15:c}");
                    
                    orderId = r.OrderID;

                    if (r.CafeOrder.Tax != null)
                        tax = (decimal)r.CafeOrder.Tax;

                    if (r.CafeOrder.Tip != null)
                        tip = (decimal)r.CafeOrder.Tip;

                    if (r.CafeOrder.AmountDue != null)
                        orderTotal = (decimal)r.CafeOrder.AmountDue;
                }

                Console.WriteLine(new string('-', 100));
                Console.WriteLine($"{"",-63} {"Tax ",12} {tax,-15:c}");
                Console.WriteLine($"{"",-63} {"Tip ",12} {tip,-15:c}");
                Utilities.SystemMessageGreen($"{"",-63} {"Order Total ",12} {orderTotal,-15:c}\n");
            }
            else
            {
                Utilities.SystemMessageRed(report.Message);
            }

            Utilities.AnyKey();
        }

        public static void GetSalesReportCategoriesByDay(IReportService service)
        {
            Console.Clear();
            Utilities.DisplayMenuHeader("Sales Report: Category Totals By Sales Date");

            DateTime date = Utilities.GetDate("Enter date (ex: 10/10/24): ");

            var report = service.GetSalesReportCategoriesByDay(date);

            if (report.Ok)
            {
                Console.Clear();
                Utilities.DisplayMenuHeader("Sales Report: Category Totals By Sales Date");

                Utilities.SystemMessageGreen($"Sales Report for: {date.Date:d}:\n");
                Utilities.SystemMessageGreen("NOTE: Totals do not include tax or tips.\n");

                Console.WriteLine(new string('-', 100));
                Console.WriteLine($"{"Category Name",-20} {"Total Sales",-15}");
                Console.WriteLine(new string('-', 100));

                decimal grandTotal = 0;

                foreach (var r in report.Data)
                {
                    Console.WriteLine($"{r.Key,-20} {r.Value,-15:c}");
                    grandTotal += r.Value;
                }

                Console.WriteLine(new string('-', 100));
                Console.WriteLine($"{"Grand Total: ",20} {grandTotal,-15:c}");
                Console.WriteLine(new string('-', 100));
            }
            else
            {
                Utilities.SystemMessageRed(report.Message);
            }

            Utilities.AnyKey();
        }
    }
}
