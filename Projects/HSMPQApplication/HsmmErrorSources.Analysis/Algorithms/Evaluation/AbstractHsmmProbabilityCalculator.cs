using System.Collections.Generic;
using HsmmErrorSources.Models.Models;

namespace HsmmErrorSources.Analysis.Algorithms.Evaluation
{
    public abstract class AbstractHsmmProbabilityCalculator<T> : IProbabilityCalculator where T : AbstractHsmModel
    {
        protected T Model;
        protected List<int> Sequence;

        protected AbstractHsmmProbabilityCalculator(T model, List<int> sequence)
        {
            Model = model;
            Sequence = sequence;
        }

        public double Calculate()
        {
            throw new System.NotImplementedException();
        }
    }
}