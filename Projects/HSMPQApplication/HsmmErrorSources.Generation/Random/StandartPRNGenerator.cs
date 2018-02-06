using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsmmErrorSources.Generation.Random
{
    public class StandartPRNGenerator: IPseudoRandomNumberGenerator
    {
        private static System.Random random = new System.Random(Convert.ToInt32(DateTime.Now.Millisecond));
        public double GetValue()
        {
            return (double)random.NextDouble(); 
        }
    }
}
