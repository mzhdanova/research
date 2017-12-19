using System;
using System.Diagnostics;

using i64 = System.Int64;
using u8 = System.Byte;
using u32 = System.UInt32;
using u64 = System.UInt64;

namespace RC4_PRNG
{
    public partial class RC4_PRNG
    {
        public class CurrentState
        {
            public bool isInit;      /* True if initialized */
            public int i;
            public int j;            /* State variables */
            public u8[] s = new u8[256];          /* State variables */

            public CurrentState Copy()
            {
                CurrentState cp = (CurrentState)MemberwiseClone();
                cp.s = new u8[s.Length];
                Array.Copy(s, cp.s, s.Length);
                return cp;
            }
        }
        public CurrentState prngstate = new CurrentState();
        public u8 randomu8()
        {
            u8 t;

            /* The "wsdPrng" macro will resolve to the pseudo-random number generator
            ** state vector.  If writable static data is unsupported on the target,
            ** we have to locate the state vector at run-time.  In the more common
            ** case where writable static data is supported, wsdPrng can refer directly
            ** to the "sqlite3Prng" state vector declared above.
            */
            CurrentState wsdPrng = prngstate;


            /* Initialize the state of the random number generator once,
** the first time this routine is called.  The seed value does
** not need to contain a lot of randomness since we are not
** trying to do secure encryption or anything like that...
**
** Nothing in this file or anywhere else in SQLite does any kind of
** encryption.  The RC4 algorithm is being used as a PRNG (pseudo-random
** number generator) not as an encryption device.
*/
            if (!wsdPrng.isInit)
            {
                int i;
                u8[] k = new u8[256];
                wsdPrng.j = 0;
                wsdPrng.i = 0;
                //sqlite3OsRandomness(sqlite3_vfs_find(""), 256, k);
                for (i = 0; i < 255; i++)
                {
                    wsdPrng.s[i] = (u8)i;
                }
                for (i = 0; i < 255; i++)
                {
                    wsdPrng.j = (u8)(wsdPrng.j + wsdPrng.s[i] + k[i]);
                    t = wsdPrng.s[wsdPrng.j];
                    wsdPrng.s[wsdPrng.j] = wsdPrng.s[i];
                    wsdPrng.s[i] = t;
                }
                wsdPrng.isInit = true;
            }

            /* Generate and return single random u8
            */
            wsdPrng.i++;
            t = wsdPrng.s[(u8)wsdPrng.i];
            wsdPrng.j = (u8)(wsdPrng.j + t);
            wsdPrng.s[(u8)wsdPrng.i] = wsdPrng.s[wsdPrng.j];
            wsdPrng.s[wsdPrng.j] = t;
            t += wsdPrng.s[(u8)wsdPrng.i];
            return wsdPrng.s[t];
        }
    }
}