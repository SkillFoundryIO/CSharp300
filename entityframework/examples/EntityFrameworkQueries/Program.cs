﻿using EntityFrameworkQueries;

var queries = new CafeQueries();

ConsoleIO.PrintCategories(queries.GetAllCategories());
ConsoleIO.PrintItems(queries.GetItemsInCategory(5), "Sandwiches");
ConsoleIO.PrintItemDetails(queries.GetItemDetails(7));

DateTime orderDate = new DateTime(2022, 1, 5);
Console.WriteLine($"\nThere were {queries.GetOrderCountForDate(orderDate)} orders on {orderDate:D}");

int categoryCount = queries.GetCategoryCount();
Console.WriteLine($"There are {categoryCount} categories in the database.");

var categoryItemCount = queries.GetItemCountByCategory();
ConsoleIO.PrintCategoryCounts(categoryItemCount);

//int id = queries.AddServer(ConsoleIO.GetNewServerInformation());
//Console.WriteLine($"The new server was created with id {id}.");

//queries.AddCategory(ConsoleIO.GetString("Enter new category: "));
//ConsoleIO.PrintCategories(queries.GetAllCategories());

//queries.UpdateServer(ConsoleIO.GetUpdatedServerInformation());

//queries.DeleteServer(int.Parse(ConsoleIO.GetString("Enter server id to delete: ")));

//queries.AddCategoryStoredProcedure(ConsoleIO.GetString("Enter new category: "));
//ConsoleIO.PrintCategories(queries.GetAllCategories());

//queries.DeleteOrder(int.Parse(ConsoleIO.GetString("Enter order id to delete: ")));

// ConsoleIO.PrintCategories(queries.GetCategoriesFromSQL());