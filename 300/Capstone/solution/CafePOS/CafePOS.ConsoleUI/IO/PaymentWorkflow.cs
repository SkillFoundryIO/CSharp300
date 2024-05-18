using CafePOS.Core.Interfaces.Services;

namespace CafePOS.ConsoleUI.IO
{
    public class PaymentWorkflow
    {
        public static void ProcessPayment(IPaymentService paymentService, IOrderService openOrderService)
        {
            OpenOrderWorkflow.ListOpenOrders(openOrderService, false, "Process Payment");

            var orderId = Utilities.GetIntZeroOrHigher("\nEnter Order ID (or 0 to cancel): ");

            if (orderId == 0)
            {
                return;
            }
            else
            {
                var orderResult = openOrderService.IsValidOpenOrder(orderId);

                if (orderResult.Ok)
                {
                    var hasItemsResult = paymentService.OrderHasItems(orderId);

                    if (hasItemsResult.Ok)
                    {
                        DisplayOrderSubtotal(paymentService, orderId);

                        var isUnder15 = paymentService.OrderIsUnder15items(orderId);

                        if (!isUnder15.Ok)
                        {
                            Utilities.SystemMessageRed(isUnder15.Message);
                        }

                        decimal tip = Utilities.GetTipAmount("\nEnter Tip Amount: ");
                        var tipResult = paymentService.AddTipToOrder(orderId, tip);

                        if (tipResult.Ok)
                        {
                            Utilities.SystemMessageGreen(tipResult.Message);
                            Utilities.AnyKey();

                            DisplayPaymentTypes(paymentService);

                            var paymentType = Utilities.GetIntZeroOrHigher("\nEnter Payment ID (or 0 to cancel): ");
                            
                            if (paymentType == 0)
                            {
                                return;
                            }
                            
                            var paymentResult = paymentService.ProcessPayment(orderId, paymentType);

                            if (paymentResult.Ok)
                            {

                                Utilities.SystemMessageGreen($"\nPayment successful and order# {orderId} is now closed out.");
                                DisplayFinalOrderTotal(paymentService, orderId);
                            }
                            else
                            {
                                Utilities.SystemMessageRed(paymentResult.Message);
                            }
                        }
                        else
                        {
                            Utilities.SystemMessageRed(tipResult.Message);
                        }
                    }
                    else
                    {
                        Utilities.SystemMessageRed(hasItemsResult.Message);
                    }
                }
                else
                {
                    Utilities.SystemMessageRed(orderResult.Message);
                }
            }

            Utilities.AnyKey();
        }

        public static void DisplayPaymentTypes(IPaymentService service)
        {
            Console.Clear();
            Utilities.DisplayMenuHeader("Process Payment");

            var paymentTypeResults = service.GetPaymentTypes();
            
            if (paymentTypeResults.Ok)
            {
                Console.WriteLine("Choose Payment Type: ");
                Console.WriteLine();
                Console.WriteLine($"{"ID",-5} {"Payment Type",-20}");

                Console.WriteLine(new string('-', 30));

                foreach (var pt in paymentTypeResults.Data)
                {
                    Console.WriteLine($"{pt.PaymentTypeID,-5} {pt.PaymentTypeName,-20}");
                }
            }
            else
            {
                Utilities.SystemMessageRed(paymentTypeResults.Message);
            }
        }

        public static void DisplayOrderSubtotal(IPaymentService service, int orderId)
        {
            var totalsResult = service.GetOrderSubtotals(orderId);
            
            if (totalsResult.Ok)
            {
                Console.Clear();
                Utilities.DisplayMenuHeader("Process Payment");

                Console.WriteLine($"Subtotals for Order# {orderId}:");
                Console.WriteLine(new string('-', 30));
                Console.WriteLine($"{"Subtotal:",12}  {totalsResult.Data.SubTotal:c}");
                Console.WriteLine($"{"Tax:",12}  {totalsResult.Data.Tax:c}");
                Console.WriteLine(new string('-', 30));
                Console.WriteLine($"{"Amount Due:",12}  {totalsResult.Data.AmountDue:c}\n");
            }
            else
            {
                Utilities.SystemMessageRed(totalsResult.Message);
            }
        }

        public static void DisplayFinalOrderTotal(IPaymentService service, int orderId)
        {
            var finalTotal = service.GetFinalTotal(orderId);
            
            if (finalTotal.Ok)
            {
                Console.Write($"\nFinal Total for Order# {orderId}: ");
                Utilities.SystemMessageGreen($"{finalTotal.Data:c}");
            }
            else
            {
                Utilities.SystemMessageRed(finalTotal.Message);
            }
        }
    }
}
