using DapperQueries.DTOs;

namespace DapperQueries
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

            if (item.Prices.Any())
            {
                foreach (var price in item.Prices)
                {
                    Console.Write($"{price.TimeOfDayName,-20}\t");
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
        public static AddServerRequest GetNewServerInformation()
        {
            var request = new AddServerRequest();

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
        public static UpdateServerRequest GetUpdatedServerInformation()
        {
            var request = new UpdateServerRequest();

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
    }
}
