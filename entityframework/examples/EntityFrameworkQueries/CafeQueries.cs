using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkQueries
{
    public class CafeQueries
    {
        private CafeContext _context = new CafeContext();

        /// <summary>
        /// Standard query, no parameters
        /// </summary>
        /// <returns></returns>
        public List<Category> GetAllCategories()
        {
            return _context.Category.ToList();
        }

        /// <summary>
        /// Gets the # of orders on a given date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public int GetOrderCountForDate(DateTime date)
        {
            return _context.CafeOrder.Count(o => o.OrderDate > date 
                && o.OrderDate < date.AddDays(1));
        }

        /// <summary>
        /// Get all the items in a category
        /// </summary>
        /// <param name="categoryID">Database id for category to select from</param>
        /// <returns></returns>
        public List<Item> GetItemsInCategory(int categoryID)
        {
            return _context.Item.Where(i => i.CategoryID == categoryID).ToList();
        }

        /// <summary>
        /// EF join syntax
        /// </summary>
        /// <param name="itemID">Item ID to Load</param>
        /// <returns></returns>
        public Item GetItemDetails(int itemID)
        {
            return _context.Item
                .Include(i=>i.Category)
                .Include(i=>i.ItemPrices)
                    .ThenInclude(ip => ip.TimeOfDay)
                .Single(i => i.ItemID == itemID);
        }

        /// <summary>
        /// The ExecuteScalar() method is used for grabbing a single value.
        /// </summary>
        /// <returns></returns>
        public int GetCategoryCount()
        {
            return _context.Category.Count();
        }

        public List<CategoryItemCount> GetItemCountByCategory()
        {
            var categoryItemCounts = _context.Item
                .Include(i => i.Category) 
                .GroupBy(i => i.Category)
                .Select(group => new CategoryItemCount
                {
                    CategoryName = group.Key.CategoryName,
                    ItemCount = group.Count()
                })
                .ToList();

            return categoryItemCounts;
        }

        /// <summary>
        /// Insert a new server record and retrieve the ServerID created
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public int AddServer(Server request)
        {
            request.HireDate = DateTime.Today;
            _context.Server.Add(request);
            _context.SaveChanges();

            return request.ServerID;
        }

        /// <summary>
        /// Insert a new category.
        /// </summary>
        /// <param name="categoryName"></param>
        public void AddCategory(string categoryName)
        {
            _context.Category.Add(
                new Category { CategoryName = categoryName });
            _context.SaveChanges();
        }

        /// <summary>
        /// Traditional approach, uses tracking
        /// </summary>
        /// <param name="request"></param>
        public void UpdateServer(Server request)
        {
            // look up entity to update
            var server = _context.Server.
               FirstOrDefault(s => s.ServerID == request.ServerID);

            // if found, copy the updated data over
            if (server != null)
            {
               // we aren't forced to updated all properties
               server.FirstName = request.FirstName;
               server.LastName = request.LastName;
               server.TermDate = request.TermDate;

               _context.SaveChanges();
            }
        }

        /// <summary>
        /// This uses the bulk update functionality
        /// </summary>
        /// <param name="request"></param>
        public void UpdateServer2(Server request)
        {
            _context.Server.Where(s => s.ServerID == request.ServerID)
            .ExecuteUpdate(setter => setter
                .SetProperty(s => s.FirstName, request.FirstName)
                .SetProperty(s => s.LastName, request.LastName)
                .SetProperty(s => s.TermDate, request.TermDate));
        }

        /// <summary>
        /// Delete a server by id with entity tracking
        /// </summary>
        /// <param name="serverID"></param>
        public void DeleteServer(int serverID)
        {
            var server = _context.Server
                .FirstOrDefault(s => s.ServerID == serverID);

            if (server != null)
            {
                _context.Server.Remove(server);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Delete a server by ID with bulk execution (no tracking)
        /// </summary>
        /// <param name="serverID"></param>
        public void DeleteServer2(int serverID)
        {
            _context.Server
                .Where(s => s.ServerID == serverID)
                .ExecuteDelete();          
        }


        /// <summary>
        /// Execute a stored procedure using the StoredProcedure command type.
        /// </summary>
        /// <param name="categoryName"></param>
        public void AddCategoryStoredProcedure(string categoryName)
        {
            _context.Database
                .ExecuteSqlInterpolated($"CategoryInsert {categoryName}");
        }

        /// <summary>
        /// Cascade delete with an implicit transaction
        /// </summary>
        /// <param name="orderID"></param>
        public void DeleteOrder(int orderID)
        {
            var items = _context.OrderItem
                .Where(oi => oi.OrderID == orderID);

            var order = _context.CafeOrder
                .FirstOrDefault(o => o.OrderID == orderID);

            if(order != null)
            {
                _context.OrderItem.RemoveRange(items);
                _context.CafeOrder.Remove(order);

                _context.SaveChanges();
            }
        }

        public void DeleteOrder2(int orderID)
        {
            //explicit transaction
            using(var transaction = _context.Database.BeginTransaction())
            {
               _context.OrderItem
                   .Where(oi => oi.OrderID == orderID)
                   .ExecuteDelete();

               _context.CafeOrder
                   .Where(o => o.OrderID == orderID)
                   .ExecuteDelete();

               transaction.Commit();
            }
        }



        /// <summary>
        /// Demonstration of using FromSql() to populate an entity list
        /// </summary>
        /// <returns></returns>
        public List<Category> GetCategoriesFromSQL()
        {
            return _context.Category.FromSql($"SELECT * FROM Category").ToList();
        }
    }
}
