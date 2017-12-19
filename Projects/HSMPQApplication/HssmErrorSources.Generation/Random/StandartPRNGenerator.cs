using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HssmErrorSources.Generation.Random
{
    class StandartPRNGenerator: IPseudoRandomNumberGenerator
    {
        private static System.Random random = new System.Random(Convert.ToInt32(DateTime.Now.Millisecond));
        double GetValue()
        {
            return (double)random.NextDouble(); 
        }
    }
}
