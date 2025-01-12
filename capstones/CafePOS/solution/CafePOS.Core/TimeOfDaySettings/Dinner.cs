using CafePOS.Core.Interfaces.Application;

namespace CafePOS.Core.TimeOfDaySettings
{
    public class Dinner : ITimeOfDaySetting
    {
        public int GetTimeOfDaySetting()
        {
            return 4;
        }
    }
}