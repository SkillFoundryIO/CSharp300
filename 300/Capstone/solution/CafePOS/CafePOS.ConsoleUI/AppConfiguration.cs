using CafePOS.Core.DTOs;
using CafePOS.Core.Interfaces.Application;
using Microsoft.Extensions.Configuration;

namespace CafePOS.ConsoleUI
{
    public class AppConfiguration : IAppConfiguration
    {
        private readonly IConfigurationRoot _configuration;

        public AppConfiguration()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .AddUserSecrets<Program>()
                .Build();
        }

        public string GetConnectionString()
        {
            return _configuration["CafeDb"] ?? "";
        }

        public TrainingMode GetTrainingModeSetting()
        {
            if (_configuration["TrainingMode"] == "")
            {
                throw new Exception("Storage configuration key missing.");
            }
            else if (_configuration["TrainingMode"] == "Enabled")
            {
                return TrainingMode.Enabled;
            }
            else if (_configuration["TrainingMode"] == "Disabled")
            {
                return TrainingMode.Disabled;
            }
            else
            {
                throw new Exception("Storage configuation is invalid.");
            }
        }

        public TimeOfDayMode GetTimeOfDayMode()
        {
            if (_configuration["TimeOfDayMode"] == "")
            {
                throw new Exception("TimeOfDayMode configuration key missing.");
            }

            switch (_configuration["TimeOfDayMode"])
            {
                case "RealTime":
                    return TimeOfDayMode.RealTime;
                case "Breakfast":
                    return TimeOfDayMode.Breakfast;
                case "Lunch":
                    return TimeOfDayMode.Lunch;
                case "HappyHour":
                    return TimeOfDayMode.HappyHour;
                case "Dinner":
                    return TimeOfDayMode.Dinner;
                case "Seasonal":
                    return TimeOfDayMode.Seasonal;
                default:
                    throw new Exception("TimeOfDayMode configuration is invalid.");
            }
        }
    }
}
