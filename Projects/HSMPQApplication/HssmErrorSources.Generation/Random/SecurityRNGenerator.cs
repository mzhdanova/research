using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HssmErrorSources.Generation.Random
{
    class CryptoServiceRNGenerator: IPseudoRandomNumberGenerator
    {
        private static RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        double GetValue()
        {
            var bytes = new Byte[8];
            provider.GetBytes(bytes);
            var ul1 = BitConverter.ToUInt64(bytes, 0) / (1 << 11);
            Double d1 = ul1 / (Double)(1UL << 53);
            return d1;
        }
    }
}
