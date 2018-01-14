using HsmmErrorSources.Generation.Models;
using HsmmErrorSources.Generation.Models.Qp;
using HsmmErrorSources.Generation.Random;
using HsmmErrorSources.Generation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsmmErrorSources.Generation.Generators
{
    public class HsmQPModelGenerator : AbstractHsmModelGenerator<HsmQPModel>
    {
        public HsmQPModelGenerator(HsmQPModel model, IPseudoRandomNumberGenerator pRNGenerator) : base(model, pRNGenerator) { }
        protected override List<int> GenerateWord(int currentState, int currentPeriod, int symbolNumber)
        {
            List<int> result = new List<int>();
            double[] errorDistribution = GenerateErrorDistribution(currentState, currentPeriod);

            double[] symbolDistribution = MatrixUtils.GetRow(model.B, currentState);

            for (int i = 0; i < symbolNumber; i++)
            {
                bool hasError = probabilityHandler.RealizeBinaryProbability(errorDistribution[i]) == 1;
                int symbol;
                if (hasError)
                {
                    symbol = probabilityHandler.RealizeProbability(symbolDistribution) + 1;
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
            double[] rho = model.Rho[currentState];
            double per = model.Per[currentState];

            double[] result = new double[currentPeriod];
            double[] phi = QpUtils.CalculateErrorLocationDistribution(rho, currentPeriod);

            for (int j = 0; j < currentPeriod; j++)
            {
                result[j] = phi[j] * per * currentPeriod;
            }
            return result;
        }

        protected override int GetCurrentWordLength(int currentPeriod, int symbolsNumberToGenerate)
        {
            return Math.Min(currentPeriod, symbolsNumberToGenerate);
        }
    }
}
