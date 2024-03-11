using CafePOS.Core.Entities;

namespace CafePOS.Core.Interfaces.Repositories
{
    public interface IServerRepository
    {
        List<Server> GetAvailableServers();
        Server? GetServer(int serverId);
        int CreateNewOrderForServer(Server server);
    }
}
