using LibraryManagement.Application.Services;
using LibraryManagement.Core.Interfaces.Application;
using LibraryManagement.Core.Interfaces.Services;
using LibraryManagement.Data.Repositories;

namespace LibraryManagement.Application
{
    public class ServiceFactory
    {
        private IAppConfiguration _config;

        public ServiceFactory(IAppConfiguration config)
        {
            _config = config;
        }

        public IBorrowerService CreateBorrowerService()
        {
            return new BorrowerService(
                new EFBorrowerRepository(_config.GetConnectionString()));
        }
    }
}
