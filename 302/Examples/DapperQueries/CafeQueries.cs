using Dapper;
using Dapper.Transaction;
using DapperQueries.DTOs;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperQueries
{
    public class CafeQueries
    {
        // Remember, in real applications don't store your connection strings in files that get pushed to GitHub!
        private const string ConnectionString = "Server=localhost,1433;Database=FourthWallCafe;User Id=sa;Password=SQLR0ck$;TrustServerCertificate=true;";

        /// <summary>
        /// Standard query, no parameters
        /// </summary>
        /// <returns></returns>
        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();

            try
            {
                using (var cn = new SqlConnection(ConnectionString))
                {
                    var sql = "SELECT * FROM Category";
                    categories = cn.Query<Category>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return categories;
        }

        /// <summary>
        /// Gets the # of orders on a given date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public int GetOrderCountForDate(DateTime date)
        {
            int count = 0;

            try
            {
                using (var cn = new SqlConnection(ConnectionString))
                {
                    var sql = @"SELECT COUNT(*) 
                          FROM CafeOrder 
                          WHERE OrderDate >= @OrderDate AND 
                          OrderDate < DateAdd(d, 1, @OrderDate)";

                    var parameters = new {
                        OrderDate = date
                    };

                    count = cn.ExecuteScalar<int>(sql, parameters);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return count;
        }

        /// <summary>
        /// Select with a parameter added to the command
        /// </summary>
        /// <param name="categoryID">Database id for category to select from</param>
        /// <returns></returns>
        public List<Item> GetItemsInCategory(int categoryID)
        {
            List<Item> items = new List<Item>();

            try
            {
                using (var cn = new SqlConnection(ConnectionString))
                {
                    var sql = @"SELECT * 
                          FROM Item 
                          WHERE CategoryID = @CategoryID";

                    var parameters = new
                    {
                        CategoryID = categoryID
                    };

                    items = cn.Query<Item>(sql, parameters).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return items;
        }

        /// <summary>
        /// Use NextResult() to Process multiple query results without hitting the database twice.
        /// </summary>
        /// <param name="itemID">Item ID to Load</param>
        /// <returns></returns>
        public Item GetItemDetails(int itemID)
        {
            Item item = new Item();

            try
            {
                using (var cn = new SqlConnection(ConnectionString))
                {
                    var sql = @"
                        SELECT i.ItemID, i.CategoryID, c.CategoryName, i.ItemName, i.ItemDescription
                        FROM Item i
                            INNER JOIN Category c ON i.CategoryID = c.CategoryID
                        WHERE ItemID = @ItemID; 

                        SELECT ip.ItemPriceID, tod.TimeOfDayName, ip.Price, ip.StartDate, ip.EndDate
                        FROM ItemPrice ip 
                            INNER JOIN TimeOfDay tod ON ip.TimeOfDayID = tod.TimeOfDayID 
                        WHERE ItemID = @ItemID ORDER BY StartDate DESC, tod.TimeOfDayID;";

                    var parameters = new
                    {
                        ItemID = itemID
                    };

                    using (var multi = cn.QueryMultiple(sql, parameters))
                    {
                        item = multi.ReadFirst<Item>();
                        item.Prices = multi.Read<ItemPrice>().ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return item;
        }

        /// <summary>
        /// The ExecuteScalar() method is used for grabbing a single value.
        /// </summary>
        /// <returns></returns>
        public int GetCategoryCount()
        {
            int count = 0;

            using (var cn = new SqlConnection(ConnectionString))
            {              
                try
                {
                    count = cn.ExecuteScalar<int>("SELECT Count(*) FROM Category");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return count;
        }

        /// <summary>
        /// Insert a new server record and retrieve the ServerID created
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public int AddServer(AddServerRequest request)
        {
            int id = 0;

            using (var cn = new SqlConnection(ConnectionString))
            {
                var sql = @"INSERT INTO [Server] (FirstName, LastName, DoB, HireDate, TermDate) 
                            VALUES (@FirstName, @LastName, @DoB, @HireDate, @TermDate);

                            SELECT SCOPE_IDENTITY();";

                try
                {
                    var parameters = new
                    {
                        request.FirstName,
                        request.LastName,
                        request.DoB,
                        HireDate = DateTime.Today,
                        TermDate = (DateTime?)null
                    };

                    id = cn.ExecuteScalar<int>(sql, parameters);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }               
            }

            return id;
        }

        /// <summary>
        /// Insert a new category.
        /// </summary>
        /// <param name="categoryName"></param>
        public void AddCategory(string categoryName)
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                var sql = @"INSERT INTO Category (CategoryName) 
                            VALUES (@CategoryName);";

                try
                {
                    cn.Execute(sql, new { CategoryName = categoryName });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Update only the fields we allow to be updated
        /// </summary>
        /// <param name="request"></param>
        public void UpdateServer(UpdateServerRequest request)
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                var sql = @"UPDATE [Server] SET 
                                FirstName = @FirstName,
                                LastName = @LastName,
                                TermDate = @TermDate
                            WHERE ServerID = @ServerID";

                var parameters = new
                {
                    request.FirstName,
                    request.LastName,
                    request.TermDate,
                    request.ServerID
                };

                try
                {
                    cn.Execute(sql, parameters);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Delete a server by id
        /// </summary>
        /// <param name="serverID"></param>
        public void DeleteServer(int serverID)
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                var sql = @"DELETE FROM [Server] WHERE ServerID = @ServerID";

                try
                {
                    cn.Execute(sql, new { ServerID = serverID });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Execute a stored procedure using the StoredProcedure command type.
        /// </summary>
        /// <param name="categoryName"></param>
        public void AddCategoryStoredProcedure(string categoryName)
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                var parameters = new { CategoryName = categoryName };

                try
                {
                    cn.Execute("CategoryInsert",
                        parameters,
                        commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Cascade delete with a transaction
        /// </summary>
        /// <param name="orderID"></param>
        public void DeleteOrder(int orderID)
        {
            var orderSQL = @"DELETE FROM [CafeOrder] WHERE OrderID = @OrderID";
            var orderItemSQL = @"DELETE FROM [OrderItem] WHERE OrderID = @OrderID";
            var parameters = new { OrderID = orderID };

            using (var cn = new SqlConnection(ConnectionString))
            {
                try
                {
                    cn.Open();

                    using (var transaction = cn.BeginTransaction())
                    {
                        transaction.Execute(orderItemSQL, parameters);
                        transaction.Execute(orderSQL, parameters);
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
