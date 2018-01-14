using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HsmmErrorSources.Generation.Models;
using HsmmErrorSources.Generation.Random;
using HsmmErrorSources.Generation.Utils;

namespace HsmmErrorSources.Generation.Generators
{
    abstract public class AbstractHsmModelGenerator<T> : IGenerator where T : AbstractHsmModel
    {
        protected T model;
        protected ProbabilityHandler probabilityHandler;

        public AbstractHsmModelGenerator(T model, IPseudoRandomNumberGenerator pRNGenerator)
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

        abstract protected List<int> GenerateWord(int currentState, int currentPeriod, int wordLength);

        abstract protected int GetCurrentWordLength(int currentPeriod, int p);

    }
}
