using System;

namespace HsmmErrorSources.Models.Utils
{
    public class DoubleUtils
    {
        private const double Epsilon = 0.00000001D;

        public static bool EqualsZero(double value) {
            return Math.Abs(value) < Epsilon;
        }

        public static bool AreEqual(double value1, double value2) {
            return Math.Abs(value1 - value2) < Epsilon;
        }
    }
}
