using HsmmErrorSources.Models.Models;
using HsmmErrorSources.Generation.Random;
using System;
using System.Collections.Generic;
using HsmmErrorSources.Models.Utils;

namespace HsmmErrorSources.Generation.Generators
{
    public class HsmFergusonModelGenerator : AbstractHsmModelGenerator<HsmFergusonModel>
    {
        public HsmFergusonModelGenerator(HsmFergusonModel model, IPseudoRandomNumberGenerator pRnGenerator) : base(model, pRnGenerator) { }
        protected override List<int> GenerateWord(int currentState, int currentPeriod, int symbolNumber)
        {
            List<int> result = new List<int>();

            double[] symbolDistribution = MatrixUtils.GetRow(Model.B, currentState);
            for (int i = 0; i < symbolNumber; i++)
            {
                result.Add(ProbabilityHandler.RealizeProbability(symbolDistribution));
            }
            return result;
        }
    }
}
