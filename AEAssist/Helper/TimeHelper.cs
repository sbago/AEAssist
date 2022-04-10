using System;

namespace AEAssist.Helper
{
    public static class TimeHelper
    {
        private static readonly DateTime Time2022 = new DateTime(2022, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long Now()
        {
            return (DateTime.UtcNow - Time2022).Ticks / 10000;
        }
    }
}