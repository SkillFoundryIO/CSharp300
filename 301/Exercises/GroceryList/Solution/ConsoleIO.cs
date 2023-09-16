namespace GroceryList
{
    public static class ConsoleIO
    {
        public static int DisplayMenu()
        {
            Console.Clear();
            int choice;

            Console.WriteLine("---- Main Menu ----");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Remove Item");
            Console.WriteLine("3. Display Items");
            Console.WriteLine("4. Exit");

            do
            {
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice >= 1 && choice <= 4)
                    {
                        return choice;
                    }

                    Console.WriteLine("Invalid choice, please try again.");
                }
            } while (true);
        }

        public static GroceryItem GetGroceryItem()
        {
            GroceryItem item = new GroceryItem();

            item.Name = GetItemName();
            item.Quantity = GetQuantity();

            return item;
        }

        private static int GetQuantity()
        {
            int quantity;

            do
            {
                Console.Write("Enter the quantity: ");
                if(int.TryParse(Console.ReadLine(), out quantity))
                {
                    if(quantity > 0)
                    {
                        return quantity;
                    }

                    Console.WriteLine("Quantity must be positive!");
                }
            } while (true);
        }

        private static string GetItemName()
        {
            string name;

            do
            {
                Console.Write("Enter the name of the grocery item: ");
                name = Console.ReadLine();

                if(!string.IsNullOrWhiteSpace(name))
                {
                    return name;
                }
            } while (true);
        }

        public static int GetItemNumberToRemove(int count)
        {
            int number;

            do
            {
                Console.Write("Enter the number of the item you want to remove: ");
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    if (number > 0 && number <= count)
                    {
                        return number;
                    }

                    Console.WriteLine("That is not a valid item number!");
                }
            } while (true);
        }

        public static void DisplayItems(List<GroceryItem> groceryList)
        {
            if (groceryList.Count == 0)
            {
                Console.WriteLine("The list is empty.\n");
                return;
            }

            int number = 1;
            foreach(var item in groceryList)
            {
                Console.WriteLine($"{number}. {item.Name} - Quantity: {item.Quantity}");
                number++;
            }

            Console.WriteLine();
        }

        public static void AnyKey()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
