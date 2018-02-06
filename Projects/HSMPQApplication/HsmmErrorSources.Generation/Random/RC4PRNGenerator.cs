using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsmmErrorSources.Generation.Random
{
    public class RC4PRNGenerator: IPseudoRandomNumberGenerator
    {
        private static RC4_PRNG rc4_prng = new RC4_PRNG();
        public double GetValue()
        {
            var bytes = new Byte[8];
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = rc4_prng.randomu8();
            var ul = BitConverter.ToUInt64(bytes, 0) / (1 << 11);
            Double d = ul / (Double)(1UL << 53);
            return d;
        }
    }
}
