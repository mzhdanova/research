using System;
using i64 = System.Int64;
using u8 = System.Byte;
using u32 = System.UInt32;
using u64 = System.UInt64;

namespace HsmmErrorSources.Generation.Random.RC4
{
    public class Rc4Prng
    {
        public class CurrentState
        {
            public bool IsInit; /* True if initialized */
            public int I;
            public int J; /* State variables */
            public u8[] S = new u8[256]; /* State variables */

            public CurrentState Copy()
            {
                CurrentState cp = (CurrentState) MemberwiseClone();
                cp.S = new u8[S.Length];
                Array.Copy(S, cp.S, S.Length);
                return cp;
            }
        }

        public CurrentState PrngState = new CurrentState();

        public u8 RandomU8()
        {
            u8 t;

            /* The "wsdPrng" macro will resolve to the pseudo-random number generator
            ** state vector.  If writable static data is unsupported on the target,
            ** we have to locate the state vector at run-time.  In the more common
            ** case where writable static data is supported, wsdPrng can refer directly
            ** to the "sqlite3Prng" state vector declared above.
            */
            CurrentState wsdPrng = PrngState;


            /* Initialize the state of the random number generator once,
            ** the first time this routine is called.  The seed value does
            ** not need to contain a lot of randomness since we are not
            ** trying to do secure encryption or anything like that...
            **
            ** Nothing in this file or anywhere else in SQLite does any kind of
            ** encryption.  The RC4 algorithm is being used as a PRNG (pseudo-random
            ** number generator) not as an encryption device.
            */
            if (!wsdPrng.IsInit)
            {
                int i;
                u8[] k = new u8[256];
                wsdPrng.J = 0;
                wsdPrng.I = 0;
                for (i = 0; i < 255; i++)
                {
                    wsdPrng.S[i] = (u8) i;
                }

                for (i = 0; i < 255; i++)
                {
                    wsdPrng.J = (u8) (wsdPrng.J + wsdPrng.S[i] + k[i]);
                    t = wsdPrng.S[wsdPrng.J];
                    wsdPrng.S[wsdPrng.J] = wsdPrng.S[i];
                    wsdPrng.S[i] = t;
                }

                wsdPrng.IsInit = true;
            }

            /* Generate and return single random u8
            */
            wsdPrng.I++;
            t = wsdPrng.S[(u8) wsdPrng.I];
            wsdPrng.J = (u8) (wsdPrng.J + t);
            wsdPrng.S[(u8) wsdPrng.I] = wsdPrng.S[wsdPrng.J];
            wsdPrng.S[wsdPrng.J] = t;
            t += wsdPrng.S[(u8) wsdPrng.I];
            return wsdPrng.S[t];
        }
    }
}