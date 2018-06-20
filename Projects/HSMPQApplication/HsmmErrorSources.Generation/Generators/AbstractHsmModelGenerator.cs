using System;
using System.Collections.Generic;
using HsmmErrorSources.Models.Models;
using HsmmErrorSources.Generation.Random;
using HsmmErrorSources.Generation.Utils;
using HsmmErrorSources.Models.Utils;

namespace HsmmErrorSources.Generation.Generators
{
    public abstract class AbstractHsmModelGenerator<T> : IGenerator where T : AbstractHsmModel
    {
        protected T Model;
        protected ProbabilityHandler ProbabilityHandler;

        protected AbstractHsmModelGenerator(T model, IPseudoRandomNumberGenerator pRnGenerator)
        {
            Model = model;
            ProbabilityHandler = new ProbabilityHandler(pRnGenerator);
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
                return ProbabilityHandler.RealizeProbability(Model.Pi);
            }
            else
            {
                double[] stateDistribution = MatrixUtils.GetRow(Model.A, (int)currentState);
                return ProbabilityHandler.RealizeProbability(stateDistribution);
            }
        }

        private int GetCurrentPeriod(int currentState)
        {
            double[] periodDistribution = MatrixUtils.GetRow(Model.F, currentState);
            return ProbabilityHandler.RealizeProbability(periodDistribution);
        }

        protected abstract List<int> GenerateWord(int currentState, int currentPeriod, int wordLength);

        protected int GetCurrentWordLength(int currentPeriod, int symbolsNumberToGenerate)
        {
            return Math.Min(currentPeriod, symbolsNumberToGenerate);
        }

    }
}
