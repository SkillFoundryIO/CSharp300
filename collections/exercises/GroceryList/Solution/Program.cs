using GroceryList;

ListManager manager = new ListManager();
Console.WriteLine("Welcome to the Grocery List Manager!");

while (true)
{
    int choice = ConsoleIO.DisplayMenu();
    Console.Clear();

    switch (choice)
    {
        case 1:        
            Console.WriteLine("---- Add Item ----");

            GroceryItem newItem = ConsoleIO.GetGroceryItem();
            manager.AddItem(newItem);
            
            Console.WriteLine("Item added successfully!\n");
            break;

        case 2:
            Console.WriteLine("---- Remove Item ----");
           
            if(manager.ItemCount > 0)
            {
                manager.DisplayItems();
                int index = ConsoleIO.GetItemNumberToRemove(manager.ItemCount);
                manager.RemoveItem(index);
                Console.WriteLine("Item removed successfully!\n");
            }
            else
            {
                Console.WriteLine("There are no items in the list.");
            }
            break;

        case 3:
            Console.WriteLine("---- Item List ----");
            manager.DisplayItems();
            break;

        case 4:
            Console.WriteLine("Thank you for using Grocery List Manager. Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid choice. Please try again.\n");
            break;

    }
    ConsoleIO.AnyKey();
}
