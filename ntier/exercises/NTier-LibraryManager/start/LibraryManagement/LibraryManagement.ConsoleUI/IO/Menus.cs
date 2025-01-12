namespace LibraryManagement.ConsoleUI.IO
{
    public static class Menus
    {
        public static int MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Library Manager Main Menu");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. List All Borrowers");
            Console.WriteLine("2. Lookup Borrower");
            Console.WriteLine("3. Add Borrower");
            Console.WriteLine("");
            Console.WriteLine("0. Quit");

            int choice;

            do
            {
                Console.Write("Enter your choice (0-3): ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice >= 0 && choice <= 3)
                    {
                        return choice;
                    }                      
                }
                
                Console.WriteLine("Invalid choice!");
            } while (true);
        }
    }
}
