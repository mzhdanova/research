using HsmmErrorSources.Generation.Random.RC4;
using System;

namespace HsmmErrorSources.Generation.Random
{
    public class Rc4PrnGenerator: IPseudoRandomNumberGenerator
    {
        private static readonly Rc4Prng Rc4Prng = new Rc4Prng();
        public double GetValue()
        {
            var bytes = new Byte[8];
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = Rc4Prng.RandomU8();
            var ul = BitConverter.ToUInt64(bytes, 0) / (1 << 11);
            Double d = ul / (Double)(1UL << 53);
            return d;
        }
    }
}
