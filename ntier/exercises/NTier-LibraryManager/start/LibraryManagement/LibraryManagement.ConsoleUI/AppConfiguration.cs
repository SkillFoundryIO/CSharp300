using LibraryManagement.Core.Interfaces.Application;
using Microsoft.Extensions.Configuration;

namespace LibraryManagement.ConsoleUI
{
    public class AppConfiguration : IAppConfiguration
    {
        private IConfiguration _configuration;

        public AppConfiguration()
        {
            _configuration = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();
        }

        public string GetConnectionString()
        {
            return _configuration["LibraryDb"] ?? "";
        }
    }
}
