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
    public abstract class HsmModelSelector : IModelSelector
    {
        protected ISelectionCriterion selectionCriterion;
        protected HsmProbabilityCalculatorFactory probabilityCalculatorFactory;

        public HsmModelSelector(ISelectionCriterion selectionCriterion) {
            this.selectionCriterion = selectionCriterion;
            probabilityCalculatorFactory = new HsmProbabilityCalculatorFactory();
        }
        public abstract IHsmModel Select(List<int> sequence, List<IHsmModel> models);
    }
}
