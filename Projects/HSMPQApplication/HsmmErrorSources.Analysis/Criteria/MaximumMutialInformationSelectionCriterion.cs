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
    public class MaximumMutialInformationSelectionCriterion : ISelectionCriterion
    {
        public IHsmModelHolder Apply(IDictionary<IHsmModelHolder, double> probabilitiesByModels)
        {
            double totalSum = probabilitiesByModels.Sum(x => x.Value);
            IDictionary<IHsmModelHolder, double> weightedProbabilitiesByModels = probabilitiesByModels.ToDictionary(entry => entry.Key, entry => entry.Value/totalSum);
            return weightedProbabilitiesByModels.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }
    }
}