# Exercise: Grocery List Manager

Start a new console application project for this exercise.

This exercise will utilize the **List<T>** collection by implementing a Grocery List Manager. Users should be able to add, remove, and edit grocery list items represented by a name and quantity.

## Requirements

Create the following class definitions and implement their functionality:

I'll help convert this class diagram into markdown format. I'll structure it to maintain the table format while being clear and readable.

### GroceryItem

| Type              | Name     | Description                 |
| ----------------- | -------- | --------------------------- |
| Property (string) | ItemName | The name of the GroceryItem |
| Property (int)    | Quantity | The quantity needed         |

### ListManager

| Type                      | Name                 | Description                                                  |
| ------------------------- | -------------------- | ------------------------------------------------------------ |
| Field (List<GroceryItem>) | _items               | The internal list of grocery items.                          |
| Method (void)             | AddItem(GroceryItem) | Adds a new GroceryItem to _items                             |
| Method (GroceryItem)      | RemoveItem(int)      | Removes the item at the index and returns it. The index should never be out of range because of the prompt logic below. |
| Method (void)             | DisplayItems()       | Displays all items in the list along with their index and quantity. |
| Method (int)              | GetCount()           | Return the current count of items in the List used for indexing. |

### ConsoleIO (static)

| Type                 | Name                             | Description                                                  |
| -------------------- | -------------------------------- | ------------------------------------------------------------ |
| Method (void)        | DisplayMenu()                    | Displays a menu of actions for the ListManager (Add Item, Remove Item, Display Items, Exit) |
| Method (GroceryItem) | GetGroceryItem()                 | Prompts the user for the item name and quantity and returns a new object instance. |
| Method (void)        | DisplayItems(List<GroceryItem\>) | Pass the list as a parameter and print the items to the console. For the numbering, add one to the index. |
| Method (int)         | GetRemovalIndex(int count)       | Given the count of items in the list, prompt the user for which item to remove. Do not allow out-of-range indexes to be returned. |

## Application Flow

Start the application with an infinite do...while loop in the **Program.cs** file. The loop should call the menu and exit if the exit (4) option is chosen.

## Sample Output

Feel free to use creativity for the output. It does not need to match exactly. This is for inspirational purposes only.

```
Welcome to the Grocery List Manager!

---- Main Menu ----
1. Add Item
2. Remove Item
3. Display Items
4. Exit

Enter your choice: 1

---- Add Item ----
Enter the name of the grocery item: Milk
Enter the quantity: 2
Item added successfully!

---- Main Menu ----
1. Add Item
2. Remove Item
3. Display Items
4. Exit

Enter your choice: 1

---- Add Item ----
Enter the name of the grocery item: Bread
Enter the quantity: 1
Item added successfully!

---- Main Menu ----
1. Add Item
2. Remove Item
3. Display Items
4. Exit

Enter your choice: 3

---- Display Items ----
1. Milk - Quantity: 2
2. Bread - Quantity: 1

Main Menu:
1. Add Item
2. Remove Item
3. Display Items
4. Exit

Enter your choice: 2

---- Remove Item ----
Enter the index of the item you want to remove: 1
Item removed successfully!

---- Main Menu ----
1. Add Item
2. Remove Item
3. Display Items
4. Exit

Enter your choice: 3

---- Display Items ----
1. Bread - Quantity: 1

---- Main Menu ----
1. Add Item
2. Remove Item
3. Display Items
4. Exit

Enter your choice: 4

Thank you for using Grocery List Manager. Goodbye!
```

