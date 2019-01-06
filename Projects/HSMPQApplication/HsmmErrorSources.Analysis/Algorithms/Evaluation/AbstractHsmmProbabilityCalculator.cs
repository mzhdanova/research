using System.Collections.Generic;
using HsmmErrorSources.Models.Models;
using System;
using HsmmErrorSources.Models.Utils;

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
            probabilityLookup = new Dictionary<int, double>();
            forwardVariableLookup = new Dictionary<Tuple<int, int, int>, double>();
        }

        public double Calculate()
        {
            return CalculateProbability(Sequence.Count);
        }

        private double CalculateProbability(int endIndex)
        {
            Console.WriteLine("Prob_" + endIndex);
            if (endIndex <= 0)
            {
                Console.WriteLine("0 Prob_" + endIndex +"="+1);
                return 1;
            }
            else
            {
                if (probabilityLookup.ContainsKey(endIndex))
                {
                    Console.WriteLine("L Prob_" + endIndex + "=" + probabilityLookup[endIndex]);
                    return probabilityLookup[endIndex];
                }
                else
                {
                    double sum = 0;
                    for (int i = 0; i < Model.N; i++)
                    {
                        for (int d = 1; d < Model.Dmax; d++)
                        {
                            for (int d1 = 1; d1 <= d; d1++)
                            {
                                double prod = CalculateProbability(endIndex - d1);

                                if (!DoubleUtils.EqualsZero(prod))
                                    prod *= CalculateForwardVariable(endIndex - d1 + d, i, d);
                                if (!DoubleUtils.EqualsZero(prod))
                                    prod *= CalculateWordProbability(endIndex - d1 + 1, endIndex - d1 + d, i, d);
                                sum += prod;
                            }
                        }
                    }
                    probabilityLookup[endIndex] = sum;
                    Console.WriteLine("S Prob_" + endIndex + "=" + sum);
                    return sum;
                }
            }
        }

        private double CalculateForwardVariable(int endIndex, int state, int duration)
        {
            Console.WriteLine("Alpha_" + endIndex + "(" + state + "," + duration + ")");
            
            if (endIndex <= 0)
            {
                Console.WriteLine("0_Alpha_" + endIndex + "(" + state + "," + duration + ")=" + Model.Pi[state] * Model.F[state, duration - 1]);
                return Model.Pi[state] * Model.F[state, duration];
            }
            else
            {
                Tuple<int, int, int> key = Tuple.Create(endIndex, state, duration);
                if (forwardVariableLookup.ContainsKey(key))
                {
                    Console.WriteLine("l_Alpha_" + endIndex + "(" + state + "," + duration + ")=" + forwardVariableLookup[key]);
                    return forwardVariableLookup[key];
                }
                else
                {
                    double sum = 0;
                    for (int i = 0; i < Model.N; i++)
                    {
                        for (int d = 1; d < Model.Dmax; d++)
                        {
                            double prod = Model.A[i, state] * Model.F[state, duration];

                            if (!DoubleUtils.EqualsZero(prod))
                                prod *= CalculateForwardVariable(endIndex - duration, i, d);
                            if (!DoubleUtils.EqualsZero(prod))
                                prod *= CalculateScaledWordProbability(endIndex - duration - d + 1, endIndex - duration, i, d);
                            sum += prod;
                        }
                    }
                    forwardVariableLookup[key] = sum;
                    Console.WriteLine("s_Alpha_" + endIndex + "(" + state + "," + duration + ")=" + sum);
                    return sum;
                }
            }
        }

        private double CalculateScaledWordProbability(int startIndex, int endIndex, int state, int duration) {
            double prod = CalculateWordProbability(startIndex, endIndex, state, duration);
            if (!DoubleUtils.EqualsZero(prod)) {
                prod *= CalculateProbability(startIndex - 1);
            }
            if (!DoubleUtils.EqualsZero(prod)) {
                prod /= CalculateProbability(endIndex);
            }
            return prod;
        }

        protected abstract double CalculateWordProbability(int startIndex, int endIndex, int state, int duration);
    }
}