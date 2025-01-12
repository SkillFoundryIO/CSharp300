using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;

namespace CafePOS.Core.Interfaces.Services
{
    public interface INewOrderService
    {
        Result<List<Server>> GetServerList();
        Result<Server> GetServer(int id);
        Result<int> CreateNewOrder(Server server);
    }
}
