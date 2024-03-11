using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.Tests.MockRepos.ServerRepo
{
    public class ServerAvailable : IServerRepository
    {
        public int CreateNewOrderForServer(Server server)
        {
            return 1;
        }

        public List<Server> GetAvailableServers()
        {
            return new List<Server>()
            {
                new Server()
            };
        }

        public Server? GetServer(int serverId)
        {
            return new Server();
        }
    }
}
