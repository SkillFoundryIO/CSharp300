using CafePOS.Core.Interfaces.Application;

namespace CafePOS.Core.TimeOfDaySettings
{
    public class Breakfast : ITimeOfDaySetting
    {
        public int GetTimeOfDaySetting()
        {
            return 1;
        }
    }
}
