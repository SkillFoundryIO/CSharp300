using CafePOS.Core.Interfaces.Application;

namespace CafePOS.Core.TimeOfDaySettings
{
    public class HappyHour : ITimeOfDaySetting
    {
        public int GetTimeOfDaySetting()
        {
            return 3;
        }
    }
}
