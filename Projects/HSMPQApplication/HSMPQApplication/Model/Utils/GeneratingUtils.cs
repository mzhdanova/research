using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RC4_PRNG;
using System.Security.Cryptography;

namespace Utils
{
    static class GeneratingUtils
    {
        private static Random r = new Random(Convert.ToInt32(DateTime.Now.Millisecond));
        static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        static RC4_PRNG.RC4_PRNG rc4_prng = new RC4_PRNG.RC4_PRNG();
        public static double rc4_Rnd()
        {
            var bytes = new Byte[8];
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = rc4_prng.randomu8();
            // Step 2: bit-shift 11 and 53 based on double's mantissa bits
            var ul = BitConverter.ToUInt64(bytes, 0) / (1 << 11);
            Double d = ul / (Double)(1UL << 53);
            return d;
        }

        public static double Rnd()
        {
            var bytes = new Byte[8];
            rng.GetBytes(bytes);
            var ul1 = BitConverter.ToUInt64(bytes, 0) / (1 << 11);
            Double d1 = ul1 / (Double)(1UL << 53);
            ////var ul = BitConverter.ToUInt64(bytes, 0) / (1 << 11);
            //Double d = BitConverter.ToUInt64(bytes, 0) / (Double)(1UL << 64);
            return d1;
        }

        public static int ProbabilityMethod(double[] a, HSMPQApplication.PRNGMode RngMode)
        /*Реализует вероятностный выбор. Наудачу кидается число и по нему выбирается 
         * нужное состояние.
         * Будет использоваться дважды - при выборе состояния канала(параметром
         * будет вектор финальных вероятностей) и при выборе нужного символа
         * (параметром будет вектор полученный с использованием матрицы условных
         * вероятностей и означающий полную верояность появления того или иного символа */
        {
            if (a == null || a.Length == 0) return 0;//подумать!!!
            int i;
            int s = 1;
            int n = a.Length;
            double[] aux = new double[n];
            for (i = 0; i < n; i++)
            {
                aux[i] = a[i];
            }
            //while (MinElementOfArray(aux) < 10)
            //{
            //    for (i = 0; i < n; i++)
            //        aux[i] = aux[i] * 10;
            //    s = s * 10;
            //}
            for (i = 1; i < n - 1; i++)
                aux[i] = aux[i - 1] + aux[i];
            aux[n - 1] = s;
            double x;
            switch (RngMode)
            {
                case HSMPQApplication.PRNGMode.Random:
                    x = (double)r.NextDouble(); break;
                case HSMPQApplication.PRNGMode.RNGCryptoServiceProvider:
                    x = (double)Rnd(); break;
                case HSMPQApplication.PRNGMode.RC4:
                    x = (double)rc4_Rnd(); break;
                default: x = 0; break;
            }            /*           Console.WriteLine("xxx");
                       Console.WriteLine(x.ToString());*/
            int index = -1;
            if ((x >= 0) && (x < aux[0])) index = 0;
            else
            {
                for (i = 1; i < n; i++)
                    if ((x >= aux[i - 1]) && (x < aux[i])) index = i;
            };
            if (x == aux[n - 1]) index = n - 1;
            /*           Console.WriteLine("prob result");
                       Console.WriteLine(index.ToString());*/
            return (index);
        }
    }
}
