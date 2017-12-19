using HsmmErrorSources.Generation.Random;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsmmErrorSources.Generation.Utils
{
    class ProbabilityHandler
    {
        private IPseudoRandomNumberGenerator generator;
        public ProbabilityHandler(IPseudoRandomNumberGenerator generator)
        {
            this.generator = generator;
        }

        public int RealizeProbability(double[] probabilities)
        {
            if (probabilities == null || probabilities.Length == 0) { return 0; }//подумать!!!
            int n = probabilities.Length;
            double[] aux = new double[n];
            for (int i = 0; i < n; i++)
            {
                aux[i] = probabilities[i];
            }
            for (int i = 1; i < n - 1; i++)
                aux[i] = aux[i - 1] + aux[i];
            aux[n - 1] = 1;
            double x = generator.GetValue();

            int index = -1;
            if (x >= 0 && x < aux[0]) { index = 0; }
            else
            {
                for (int i = 1; i < n; i++)
                    if (x >= aux[i - 1] && x < aux[i]) index = i;
            };
            if (x == aux[n - 1]) { index = n - 1; }
            return index;
        }

        public int RealizeBinaryProbability(double probability)
        {
            if (DoubleUtils.EqualsZero(probability)) { return 0; }
            double x = generator.GetValue();
            if (x < probability) return 1; else return 0;
        }
    }
}
