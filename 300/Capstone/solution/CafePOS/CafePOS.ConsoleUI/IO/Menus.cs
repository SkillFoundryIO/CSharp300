namespace CafePOS.ConsoleUI.IO
{
    public class Menus
    {
        public static int MainMenu()
        {
            Console.Clear();
            Utilities.DisplayMenuHeader("Main Menu");
            
            Console.WriteLine("1. Create New Order");
            Console.WriteLine("2. Add Items to Open Order");
            Console.WriteLine("3. View Open Orders");
            Console.WriteLine("4. Cancel Order");
            Console.WriteLine("5. Process Payment");
            Console.WriteLine("6. Sales Report - Orders & Order Details By Day");
            Console.WriteLine("7. Sales Report - Category Totals By Day");
            Console.WriteLine();
            Console.WriteLine("0. Quit");

            return Utilities.GetChoiceInRange(0, 7);
        }
    }
}
