using HsmmErrorSources.Models.Models;
using HsmmErrorSources.Generation.Random;
using HsmmErrorSources.Generation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsmmErrorSources.Generation.Generators
{
    public class HsmFergusonModelGenerator : AbstractHsmModelGenerator<HsmFergusonModel>
    {
        public HsmFergusonModelGenerator(HsmFergusonModel model, IPseudoRandomNumberGenerator pRNGenerator) : base(model, pRNGenerator) { }
        override protected List<int> GenerateWord(int currentState, int currentPeriod, int symbolNumber)
        {
            List<int> result = new List<int>();

            double[] symbolDistribution = MatrixUtils.GetRow(model.B, currentState);
            for (int i = 0; i < symbolNumber; i++)
            {
                result.Add(probabilityHandler.RealizeProbability(symbolDistribution));
            }
            return result;
        }

        override protected int GetCurrentWordLength(int currentPeriod, int symbolsNumberToGenerate)
        {
            return Math.Min(currentPeriod, symbolsNumberToGenerate);
        }
    }
}
