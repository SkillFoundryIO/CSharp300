using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.Data.TrainingRepositories
{
    public class TrainingServerRepository : IServerRepository
    {
        public List<Server> GetAvailableServers()
        {
            return FakeDb.Servers.ToList();
        }

        public Server? GetServer(int serverId)
        {
            return FakeDb.Servers
               .FirstOrDefault(s => s.ServerID == serverId);
        }

        public int CreateNewOrderForServer(Server server)
        {
            var order = new CafeOrder();
            order.OrderID = FakeDb.CafeOrders.Count() + 1;
            order.ServerID = server.ServerID;
            order.OrderDate = DateTime.Now;

            FakeDb.CafeOrders.Add(order);

            return order.OrderID;
        }
    }
}
