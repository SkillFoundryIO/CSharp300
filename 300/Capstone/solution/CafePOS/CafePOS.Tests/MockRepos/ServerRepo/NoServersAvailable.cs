using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;

namespace CafePOS.Tests.MockRepos.ServerRepo
{
    public class NoServersAvailable : IServerRepository
    {
        public int CreateNewOrderForServer(Server server)
        {
            throw new NotImplementedException();
        }

        public List<Server> GetAvailableServers()
        {
            return new List<Server>();
        }

        public Server? GetServer(int serverId)
        {
            return null;
        }
    }
}
