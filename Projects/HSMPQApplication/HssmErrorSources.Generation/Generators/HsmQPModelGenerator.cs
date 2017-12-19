using HsmmErrorSources.Generation.Models;
using HsmmErrorSources.Generation.Random;
using HsmmErrorSources.Generation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsmmErrorSources.Generation.Generators
{
    public class HsmQPModelGenerator : IGenerator
    {
        private HsmQPModel model;
        private ProbabilityHandler probabilityHandler;

        public HsmQPModelGenerator(HsmQPModel model, IPseudoRandomNumberGenerator pRNGenerator)
        {
            this.model = model;
            this.probabilityHandler = new ProbabilityHandler(pRNGenerator);
        }

        public IList<int> Generate(int sequenceLength)
        {
            List<int> result = new List<int>(sequenceLength);

            int currentState = GetNextState(null);
            int currentPeriod = GetCurrentPeriod(currentState);

            int wordLength = GetCurrentWordLength(currentPeriod, sequenceLength);
            List<int> word = GenerateWord(currentState, currentPeriod, wordLength);
            result.AddRange(word);

            for (int counter = currentPeriod; counter < sequenceLength; counter += currentPeriod)
            {
                currentState = GetNextState(currentState);
                currentPeriod = GetCurrentPeriod(currentState);

                wordLength = GetCurrentWordLength(currentPeriod, sequenceLength - counter);
                word = GenerateWord(currentState, currentPeriod, wordLength);
                result.AddRange(word);
            }

            return result;
        }

        private List<int> GenerateWord(int currentState, int currentPeriod, int symbolNumber)
        {
            List<int> result = new List<int>();
            double[] rho = model.Rho[currentState];
            double[] errorDistribution = ScaleModelErrorDistribution(rho, rho.Length, currentPeriod);

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
        /// <returns>next state of the model</returns>
        private double[] GenerateErrorDistribution(int currentState, int currentPeriod)
        {
            int modelSegmentLength = model.Rho[currentState].Length;

            double[] result = new double[currentPeriod];//вероятность ошибки в момент j
            double[] Phi = ScaleModelErrorDistribution(model.Rho[currentState], modelSegmentLength, currentPeriod);

            for (int j = 0; j < currentPeriod; j++)
            {
                result[j] = Phi[j] * model.Per[currentState] * currentPeriod;
            }
            return result;
        }

        private static double[] ScaleModelErrorDistribution(double[] rho, int l, int t)
        {
            double[] phi = new double[t];
            double nm = (double)(Convert.ToDouble(l) / Convert.ToDouble(t));//длина растяжения старого единичного отрезка в единицах нового

            if (nm <= 1)//старый единичный больше, чем новый единичный, тогда в новом отрезке больше точек, чем в старом
            {
                double d = 1 / nm;
                for (int i = 0; i < t; i++)
                {
                    if (i + 1 <= d)
                    {
                        phi[i] = FiPc(rho, l, t, i + 1);
                    }
                    else
                    {
                        phi[i] = (d - i) * FiPc(rho, l, t, d) + (i + 1 - d) * FiPc(rho, l, t, i + 1);
                        d += 1 / nm;
                    }
                }
            }
            else //если новый единичный больше старого единичного, тогда точек в старом больше 
            {
                double delta_j = 1 / nm;
                double k = delta_j;
                double j;
                for (int i = 0; i <= t - 1; i++)
                {
                    for (j = k; (j < i + 1) && (j <= l * delta_j); j += delta_j)
                    {
                        phi[i] += FiPc(rho, l, t, j) * delta_j;
                    }
                    if (j >= i + 1)
                    {
                        k = j;
                        phi[i] += FiPc(rho, l, t, i + 1) * (i + 1 - k + delta_j);
                        if (j.CompareTo(l * delta_j) == -1)
                            phi[i + 1] = FiPc(rho, l, t, k) * (k - i - 1);
                    }

                    else break;
                    k += delta_j;
                }
            }
            return phi;
        }

        private static double FiPc(double[] Ro, int L, int T, double j)//эталонный L,новый T
        {
            int i = 0;
            double s = -1;
            double nm = (double)(Convert.ToDouble(T) / Convert.ToDouble(L));
            double mn = (double)(1.0 / nm);
            while (i < L)
            {
                if (((nm * i).CompareTo(j) <= 0)
                    && (j.CompareTo(nm * (i + 1)) <= 0))
                {
                    s = (mn) * Ro[i];
                    break;
                }
                else i++;
            }
            return s;
        }

        /// <summary>
        /// Returns the next state of the model based on the current state. 
        /// </summary>
        /// <param name="currentState">current state index. If set to null then next state is calculated
        /// based on the initial state distribution Pi</param>
        /// <returns>next state of the model</returns>
        private int GetNextState(int? currentState)
        {
            if (currentState == null)
            {
                return probabilityHandler.RealizeProbability(model.Pi);
            }
            else
            {
                double[] stateDistribution = MatrixUtils.GetRow(model.A, (int)currentState);
                return probabilityHandler.RealizeProbability(stateDistribution);
            }
        }

        private int GetCurrentPeriod(int currentState)
        {
            double[] periodDistribution = MatrixUtils.GetRow(model.F, currentState);
            return probabilityHandler.RealizeProbability(periodDistribution);
        }

        private int GetCurrentWordLength(int currentPeriod, int symbolsNumberToGenerate)
        {
            return Math.Min(currentPeriod, symbolsNumberToGenerate);
        }
    }
}
