using HssmErrorSources.Generation.Models;
using HssmErrorSources.Generation.Random;
using HssmErrorSources.Generation.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HssmErrorSources.Generation.Generators
{
    class HiddenSemiMarkovFergusonModelGenerator : IGenerator
    {
        private HiddenSemiMarkovFergusonModel model;
        private ProbabilityHandler probabilityHandler;

        public HiddenSemiMarkovFergusonModelGenerator(HiddenSemiMarkovFergusonModel model, IPseudoRandomNumberGenerator pRNGenerator)
        {
            this.model = model;
            this.probabilityHandler = new ProbabilityHandler(pRNGenerator);
        }

        public List<int> Generate(int sequenceLength)
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

        public List<int> GenerateWord(int currentState, int currentPeriod, int symbolNumber)
        {
            List<int> result = new List<int>();

            double[] symbolDistribution = MatrixUtils.GetRow(model.B, currentState);
            for (int i = 0; i < symbolNumber; i++)
            {
                result.Add(probabilityHandler.RealizeProbability(symbolDistribution));
            }
            return result;
        }
        /// <summary>
        /// Returns the next state of the model based on the current state. 
        /// </summary>
        /// <param name="currentState">current state index. If set to null then next state is calculated
        /// based on the initial state distribution Pi</param>
        /// <returns>next state of the model</returns>
        public int GetNextState(int? currentState)
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

        public int GetCurrentPeriod(int currentState)
        {
            double[] periodDistribution = MatrixUtils.GetRow(model.F, currentState);
            return probabilityHandler.RealizeProbability(periodDistribution);
        }

        public int GetCurrentWordLength(int currentPeriod, int symbolsNumberToGenerate)
        {
            return Math.Min(currentPeriod, symbolsNumberToGenerate);
        }
    }
}
