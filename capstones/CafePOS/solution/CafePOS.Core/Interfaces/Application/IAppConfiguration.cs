using CafePOS.Core.DTOs;

namespace CafePOS.Core.Interfaces.Application
{
    public interface IAppConfiguration
    {
        string GetConnectionString();
        TimeOfDayMode GetTimeOfDayMode();
        TrainingMode GetTrainingModeSetting();
    }
}
