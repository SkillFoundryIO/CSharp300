using CafePOS.Core.DTOs;
using CafePOS.Core.Entities;
using CafePOS.Core.Interfaces.Repositories;
using CafePOS.Core.Interfaces.Services;

namespace CafePOS.Application.Services
{
    public class NewOrderService : INewOrderService
    {
        private readonly IServerRepository _sereverRepository;

        public NewOrderService(IServerRepository sereverRepository)
        {
            _sereverRepository = sereverRepository;
        }

        public Result<List<Server>> GetServerList()
        {
            try
            {
                var servers = _sereverRepository.GetAvailableServers();

                if (servers.Count() == 0)
                {
                    return ResultFactory.Fail<List<Server>>("No servers are available currently.");
                }
                else
                {
                    return ResultFactory.Success(servers);
                }
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<List<Server>>(ex.Message);
            }

        }

        public Result<Server> GetServer(int id)
        {
            try
            {
                var server = _sereverRepository.GetServer(id);

                if (server == null)
                {
                    return ResultFactory.Fail<Server>($"Server ID {id} is not available currently.");
                }
                else
                {
                    return ResultFactory.Success(server);
                }
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<Server>(ex.Message);
            }
        }

        public Result<int> CreateNewOrder(Server server)
        {
            try
            {
                var orderId = _sereverRepository.CreateNewOrderForServer(server);

                return ResultFactory.Success(orderId);
            }
            catch (Exception ex)
            {
                return ResultFactory.Fail<int>(ex.Message);
            }

        }
    }
}
