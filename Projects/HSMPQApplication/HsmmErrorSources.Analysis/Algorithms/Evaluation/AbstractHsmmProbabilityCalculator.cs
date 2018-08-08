using System.Collections.Generic;
using HsmmErrorSources.Models.Models;

namespace HsmmErrorSources.Analysis.Algorithms.Evaluation
{
    public abstract class AbstractHsmmProbabilityCalculator<T> : IProbabilityCalculator where T : AbstractHsmModel
    {
        protected T Model;
        protected List<int> Sequence;

        private IDictionary<int, double> probabilityLookup;
        private IDictionary<Tuple<int, int, int>, double> forwardVariableLookup;

        protected AbstractHsmmProbabilityCalculator(T model, List<int> sequence)
        {
            Model = model;
            Sequence = sequence;
            probabilityLookup = new Dictionary();
            forwardVariableLookup = new Dictionary();
        }

        public double Calculate()
        {
            return CalculateProbability(Sequence.Count);
        }

        private double CalculateProbability(int endIndex) {
            if (endIndex <= 0)
            {
                return 1;
            }
            else {
                if (probabilityLookup.ContainsKey(endIndex))
                {
                    return probabilityLookup[endIndex];
                }
                else {
                    double sum = 0;
                    for (int i = 0; i < Model.N; i++) {
                    for (int d=1; d<= Model.F.GetLength(1); d++){
                        for (int d1 = 1; d1 <= d; d1++)
                        {
                            double prod = CalculateProbability(endIndex - d);
                            // если первый множитель 0, то остальные можно не считать.
                            if (prod != 0F)
                                prod *= CalculateForwardVariable(endIndex, i, d);
                            if (prod != 0F)
                                prod *= CalculateWordProbability(endIndex - d1 +1, endIndex-d1+d, i, d);
                            sum += prod;
                        }
                    }
                    }
                    probabilityLookup[endIndex] = sum;
                }
            }
        }

        private double CalculateForwardVariable(int endIndex, int state, int duration) {
            if (endIndex <= 0)
            {
                return Model.Pi*Model.F[state, duration];
            }
            else
            {
                Tuple key = new Tuple(endIndex, state, duration);
                if (forwardVariableLookup.ContainsKey(key))
                {
                    return forwardVariableLookup[key];
                }
                else
                {
                    double sum = 0;
                    for (int i = 0; i < Model.N; i++)
                    {
                        for (int d = 1; d <= Model.F.GetLength(1); d++)
                        {
                                double prod = Model.A[i, state] * Model.F[state, duration];
                                // если первый множитель 0, то остальные можно не считать.
                                if (prod != 0F)
                                    prod *= CalculateForwardVariable(endIndex-duration, i, d);
                                if (prod != 0F)
                                    prod *= CalculateWordProbability(endIndex - duration- d + 1, endIndex - duration, i, d);
                                sum += prod;
                        }
                    }
                    forwardVariableLookup[key] = sum;
                }
            }
          }

        protected abstract double CalculateWordProbability(int startIndex, int endIndex, int state, int duration);
    }
}