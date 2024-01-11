using AdoNetQueries.DTOs;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdoNetQueries
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
                    var cmd = new SqlCommand("SELECT * FROM Category", cn);
                    cn.Open();

                    using(var dr = cmd.ExecuteReader()) 
                    { 
                        while(dr.Read())
                        {
                            var item = new Category();

                            item.CategoryID = (int)dr["CategoryID"];
                            item.CategoryName = (string)dr["CategoryName"];

                            categories.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return categories;
        }

        public int GetOrderCountForDate(DateTime date)
        {
            int count = 0;

            try
            {
                using (var cn = new SqlConnection(ConnectionString))
                {
                    var cmd = new SqlCommand(
                        @"SELECT COUNT(*) 
                          FROM CafeOrder 
                          WHERE OrderDate >= @OrderDate AND OrderDate < DateAdd(d, 1, @OrderDate)", cn);

                    cmd.Parameters.AddWithValue("@OrderDate", date);

                    cn.Open();

                    count = (int)cmd.ExecuteScalar();
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
                    var cmd = new SqlCommand(
                        @"SELECT * 
                          FROM Item 
                          WHERE CategoryID = @CategoryID", cn);

                    cmd.Parameters.AddWithValue("@CategoryID", categoryID);

                    cn.Open();

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var item = new Item();

                            item.ItemID = (int)dr["ItemID"];
                            item.ItemName = (string)dr["ItemName"];
                            item.ItemDescription = (string)dr["ItemDescription"];

                            items.Add(item);
                        }
                    }
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
                    var cmd = new SqlCommand(@"
                        SELECT i.ItemID, i.CategoryID, c.CategoryName, i.ItemName, i.ItemDescription
                        FROM Item i
                            INNER JOIN Category c ON i.CategoryID = c.CategoryID
                        WHERE ItemID = @ItemID; 

                        SELECT ip.ItemPriceID, tod.TimeOfDayName, ip.Price, ip.StartDate, ip.EndDate
                        FROM ItemPrice ip 
                            INNER JOIN TimeOfDay tod ON ip.TimeOfDayID = tod.TimeOfDayID 
                        WHERE ItemID = @ItemID ORDER BY StartDate DESC, tod.TimeOfDayID;", cn);

                    cmd.Parameters.AddWithValue("@ItemID", itemID);

                    cn.Open();

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            item.ItemID = (int)dr["ItemID"];
                            item.ItemName = (string)dr["ItemName"];
                            item.ItemDescription = (string)dr["ItemDescription"];
                            item.Category.CategoryName = (string)dr["CategoryName"];
                            item.Category.CategoryID = (int)dr["CategoryID"];

                            dr.NextResult();
                            while (dr.Read())
                            {
                                var ip = new ItemPrice();

                                ip.ItemPriceID = (int)dr["ItemPriceID"];
                                ip.Price = (decimal)dr["Price"];
                                ip.TimeOfDayName = (string)dr["TimeOfDayName"];
                                ip.StartDate = (DateTime)dr["StartDate"];
                                ip.EndDate = dr["EndDate"] == DBNull.Value ? null : (DateTime)dr["EndDate"];

                                item.Prices.Add(ip);
                            }
                        }
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

            using(var cn = new SqlConnection(ConnectionString))
            {
                var sql = "SELECT Count(*) FROM Category";

                var cmd = new SqlCommand(sql, cn);

                try
                {
                    cn.Open();
                    count = (int)cmd.ExecuteScalar();
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
                    cn.Open();
                    var cmd = new SqlCommand(sql, cn);

                    cmd.Parameters.AddWithValue("@FirstName", request.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", request.LastName);
                    cmd.Parameters.AddWithValue("@DoB", request.DoB);
                    cmd.Parameters.AddWithValue("@HireDate", DateTime.Today);
                    cmd.Parameters.AddWithValue("@TermDate", DBNull.Value);

                    id = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return id;
            }
        }

        /// <summary>
        /// Insert a new category.
        /// </summary>
        /// <param name="categoryName"></param>
        public void AddCategory(string categoryName)
        {
            using (var cn = new SqlConnection(ConnectionString))
            {
                var sql = @"INSERT INTO Category (CategoryName) VALUES (@CategoryName);";

                try
                {
                    cn.Open();
                    var cmd = new SqlCommand(sql, cn);

                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);

                    cmd.ExecuteNonQuery();
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

                try
                {
                    cn.Open();
                    var cmd = new SqlCommand(sql, cn);

                    cmd.Parameters.AddWithValue("@FirstName", request.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", request.LastName);
                    cmd.Parameters.AddWithValue("@TermDate", 
                        request.TermDate.HasValue ? request.TermDate : DBNull.Value);
                    cmd.Parameters.AddWithValue("@ServerID", request.ServerID);

                    cmd.ExecuteNonQuery();
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
                    cn.Open();
                    var cmd = new SqlCommand(sql, cn);

                    cmd.Parameters.AddWithValue("@ServerID", serverID);

                    cmd.ExecuteNonQuery();
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
                try
                {
                    cn.Open();
                    var cmd = new SqlCommand("CategoryInsert", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);

                    cmd.ExecuteNonQuery();
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
            using (var cn = new SqlConnection(ConnectionString))
            {
                var orderSQL = @"DELETE FROM [CafeOrder] WHERE OrderID = @OrderID";
                var orderItemSQL = @"DELETE FROM [OrderItem] WHERE OrderID = @OrderID";

                cn.Open();
                var transaction = cn.BeginTransaction();

                try
                {
                    var cmd1 = new SqlCommand(orderItemSQL, cn);
                    cmd1.Parameters.AddWithValue("@OrderID", orderID);
                    cmd1.Transaction = transaction;

                    var cmd2 = new SqlCommand(orderSQL, cn);
                    cmd2.Parameters.AddWithValue("@OrderID", orderID);
                    cmd2.Transaction = transaction;

                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception tn)
                    {
                        Console.WriteLine(tn.Message);
                    }                 
                }
            }
        }
    }
}
