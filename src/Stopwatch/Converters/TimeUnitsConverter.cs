namespace StopwatchApplication.Converters
{
    internal class TimeUnitsConverter
    {
        private const int SecondsInAMinute = 60;
        private const int MinutesInAnHour = 60;
        private const int HoursInADay = 24;
        private const int MillisInASecond = 1000;
        private const int MillisInAMinute = MillisInASecond * SecondsInAMinute;
        private const int MillisInAnHour = MillisInAMinute * MinutesInAnHour;

        public short GetSeconds(long milliSeconds)
        {
            return (short)((milliSeconds / MillisInASecond) % SecondsInAMinute);
        }

        public short GetMinutes(long milliSeconds)
        {
            return (short)((milliSeconds / MillisInAMinute) % MinutesInAnHour);
        }

        public short GetHours(long milliSeconds)
        {
            return (short)((milliSeconds / MillisInAnHour) % HoursInADay);
        }
    }
}
