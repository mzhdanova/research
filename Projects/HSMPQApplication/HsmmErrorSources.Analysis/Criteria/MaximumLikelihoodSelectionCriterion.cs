using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HsmmErrorSources.Analysis.Algorithms.Evaluation;
using HsmmErrorSources.Analysis.Criteria;
using HsmmErrorSources.Models.Models;

namespace HsmmErrorSources.Analysis.Algorithms.Criteria
{
    public class MaximumLikelihoodSelectionCriterion : ISelectionCriterion
    {
        public IHsmModelHolder Apply(IDictionary<IHsmModelHolder, double> probabilitiesByModels)
        {
            return probabilitiesByModels.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }
    }
}