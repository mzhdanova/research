using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HsmmErrorSources.Analysis.Algorithms.Evaluation;
using HsmmErrorSources.Analysis.Criteria;
using HsmmErrorSources.Models.Models;

namespace HsmmErrorSources.Analysis.Algorithms.Selection
{
    public class SimpleHsmModelSelector : HsmModelSelector
    {
        public SimpleHsmModelSelector(ISelectionCriterion selectionCriterion) : base(selectionCriterion){}
        public override IHsmModel Select(List<int> sequence, List<IHsmModel> models)
        {
            IDictionary<IHsmModel, double> probabilitiesByModels = models.ToDictionary(m => m, m => {
                IProbabilityCalculator probabilityCalculator = probabilityCalculatorFactory.CreateProbabilityCalculator(m, sequence);
                return probabilityCalculator.Calculate();
            });
            return selectionCriterion.Apply(probabilitiesByModels);
        }
    }
}