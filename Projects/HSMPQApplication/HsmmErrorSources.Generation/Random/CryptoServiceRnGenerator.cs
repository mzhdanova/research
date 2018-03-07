using System;
using System.Security.Cryptography;

namespace HsmmErrorSources.Generation.Random
{
    public class CryptoServiceRnGenerator: IPseudoRandomNumberGenerator
    {
        private static readonly RNGCryptoServiceProvider Provider = new RNGCryptoServiceProvider();
        public double GetValue()
        {
            var bytes = new Byte[8];
            Provider.GetBytes(bytes);
            var ul1 = BitConverter.ToUInt64(bytes, 0) / (1 << 11);
            Double d1 = ul1 / (Double)(1UL << 53);
            return d1;
        }
    }
}
