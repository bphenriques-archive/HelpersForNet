using System;

namespace HelpersForNet {
    public static class RandomExtensions {
        public static double GetRandomNumber(this Random random, double minimum, double maximum) {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        public static int GetRandomNumber(this Random random, int minimum, int maximum) {
            return random.Next(minimum, maximum);
        }
    }
}
