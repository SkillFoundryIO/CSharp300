using CafePOS.Core.Interfaces.Application;

namespace CafePOS.Core.TimeOfDaySettings
{
    public class RealTime : ITimeOfDaySetting
    {
        public int GetTimeOfDaySetting()
        {
            DateTime now = DateTime.Now;

            if (now.Hour >= 6 && now.Hour < 12)
            {
                return 1;
            }
            if (now.Hour >= 12 && now.Hour < 17)
            {
                return 2;
            }
            if (now.Hour >= 17 && now.Hour < 18)
            {
                return 3;
            }
            if (now.Hour >= 18 && now.Hour < 20)
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }
    }
}
