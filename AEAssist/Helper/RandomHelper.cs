using System;

namespace AEAssist.Helper
{
    public static class RandomHelper
    {
        private static readonly Random _random = new Random();

        public static float RandomFloat(float min, float max)
        {
            if (min >= max)
                return min;
            var delta = max - min;
            var value = RandomInt(10, 1000);
            return value * delta / 1000;
        }

        public static int RandomInt(int min, int max)
        {
            if (min >= max)
                return min;
            return _random.Next(min, max);
        }
        public static bool RandomBool()
        {
            var value = RandomInt(0, 1);
            if (value == 0)
                return false;
            return true;
        }
    }
}