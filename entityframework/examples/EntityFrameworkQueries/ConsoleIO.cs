namespace EntityFrameworkQueries
{
    public static class ConsoleIO
    {
        public static void PrintCategories(List<Category> categories)
        {
            Console.WriteLine("Category List");
            Console.WriteLine("=============");

            foreach (var c in categories)
            {
                Console.WriteLine($"{c.CategoryID}\t{c.CategoryName}");
            }
        }

        public static void PrintItems(List<Item> items, string categoryName)
        {
            Console.WriteLine($"\nItems in {categoryName}");
            Console.WriteLine("=============================");

            if (items.Any())
            {
                foreach (var i in items)
                {
                    Console.WriteLine($"{i.ItemName}\n\t{i.ItemDescription}");
                }
            }
            else
            {
                Console.WriteLine("No items found!");
            }
        }

        public static void PrintItemDetails(Item item)
        {
            Console.WriteLine($"\n{item.ItemName} Details");
            Console.WriteLine("=============================");
            Console.WriteLine($"Category: {item.Category.CategoryName}");
            Console.WriteLine($"Description: {item.ItemDescription}");
            Console.WriteLine("\nPrice History");
            Console.WriteLine("=============================");

            if (item.ItemPrices.Any())
            {
                foreach (var price in item.ItemPrices)
                {
                    Console.Write($"{price.TimeOfDay.TimeOfDayName,-20}\t");
                    Console.Write($"{price.Price:c}\t");
                    Console.Write($"{price.StartDate:d} - ");
                    Console.WriteLine($"{(price.EndDate.HasValue ? price.EndDate.Value.ToString("d") : "Active")} ");
                }
            }
            else
            {
                Console.WriteLine("None");
            }
        }

        /// <summary>
        /// Populates the add server request.
        /// We're skipping validation for brevity
        /// </summary>
        /// <returns></returns>
        public static Server GetNewServerInformation()
        {
            var request = new Server();

            request.FirstName = GetString("Enter first name: ");
            request.LastName = GetString("Enter last name: ");
            request.DoB = DateTime.Parse(GetString("Enter dob: "));

            return request;
        }

        /// <summary>
        /// Populates an update request. It handles a null term date by using the IsNullOrWhiteSpace() method 
        /// which is a common technique.
        /// </summary>
        /// <returns></returns>
        public static Server GetUpdatedServerInformation()
        {
            var request = new Server();

            request.ServerID = int.Parse(GetString("Enter server id: "));
            request.FirstName = GetString("Enter first name: ");
            request.LastName = GetString("Enter last name: ");

            string termDate = GetString("Enter term date: ");
            request.TermDate = string.IsNullOrWhiteSpace(termDate) ? null : DateTime.Parse(termDate);

            return request;
        }

        public static string GetString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static void PrintCategoryCounts(List<CategoryItemCount> categoryItemCount)
        {
            Console.WriteLine(string.Format("{0,-40}", "Category") + "Count");
            foreach(var c in categoryItemCount)
            {
                Console.WriteLine($"{c.CategoryName,-40}{c.ItemCount}");
            }
        }
    }
}
