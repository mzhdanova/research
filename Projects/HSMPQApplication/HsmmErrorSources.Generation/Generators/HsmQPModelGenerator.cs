using HsmmErrorSources.Models.Models;
using HsmmErrorSources.Models.Models.Qp;
using HsmmErrorSources.Generation.Random;
using System;
using System.Collections.Generic;
using HsmmErrorSources.Models.Utils;

namespace HsmmErrorSources.Generation.Generators
{
    public class HsmQpModelGenerator : AbstractHsmModelGenerator<HsmQpModel>
    {
        public HsmQpModelGenerator(HsmQpModel model, IPseudoRandomNumberGenerator pRnGenerator) : base(model, pRnGenerator) { }
        protected override List<int> GenerateWord(int currentState, int currentPeriod, int symbolNumber)
        {
            List<int> result = new List<int>();
            double[] errorDistribution = GenerateErrorDistribution(currentState, currentPeriod);

            double[] symbolDistribution = MatrixUtils.GetRow(Model.B, currentState);

            for (int i = 0; i < symbolNumber; i++)
            {
                bool hasError = ProbabilityHandler.RealizeBinaryProbability(errorDistribution[i]) == 1;
                int symbol;
                if (hasError)
                {
                    symbol = ProbabilityHandler.RealizeProbability(symbolDistribution) + 1;
                }
                else { symbol = 0; }

                result.Add(symbol);
            }
            return result;
        }
        /// <summary>
        /// Generates the error probabilities distribution for the specified state and duration calculated according to QP scaling algorithm. 
        /// </summary>
        /// <param name="currentState">current state index. </param>
        /// <param name="currentPeriod">curreny period length</param>
        /// <returns>probabilities of error inside the current period (index stands for point in the period)</returns>
        private double[] GenerateErrorDistribution(int currentState, int currentPeriod)
        {
            double[] rho = Model.Rho[currentState];
            double per = Model.Per[currentState];

            double[] result = new double[currentPeriod];
            double[] phi = QpUtils.CalculateErrorLocationDistribution(rho, currentPeriod);

            for (int j = 0; j < currentPeriod; j++)
            {
                result[j] = phi[j] * per * currentPeriod;
            }
            return result;
        }
    }
}
