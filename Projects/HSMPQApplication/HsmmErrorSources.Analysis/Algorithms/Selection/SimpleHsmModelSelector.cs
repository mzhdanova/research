using System.Collections.Generic;
using System.Linq;
using HsmmErrorSources.Analysis.Algorithms.Evaluation;
using HsmmErrorSources.Analysis.Criteria;
using HsmmErrorSources.Models.Models;

namespace HsmmErrorSources.Analysis.Algorithms.Selection
{
    public class SimpleHsmModelSelector : HsmModelSelector
    {
        public SimpleHsmModelSelector(ISelectionCriterion selectionCriterion) : base(selectionCriterion){}
        public override IHsmModelHolder Select(List<int> sequence, List<IHsmModelHolder> models)
        {
            IDictionary<IHsmModelHolder, double> probabilitiesByModels = models.ToDictionary(m => m, m => {
                IProbabilityCalculator probabilityCalculator = probabilityCalculatorFactory.CreateProbabilityCalculator(m.Model, sequence);
                return probabilityCalculator.Calculate();
            });
            return selectionCriterion.Apply(probabilitiesByModels);
        }
    }
}