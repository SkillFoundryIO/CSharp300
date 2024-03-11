using CafePOS.Core.Interfaces.Application;

namespace CafePOS.Core.TimeOfDaySettings
{
    public class Lunch : ITimeOfDaySetting
    {
        public int GetTimeOfDaySetting()
        {
            return 2;
        }
    }
}
