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
    public class HsmModelSelector : IModelSelector
    {
        private ISelectionCriterion SelectionCriterion;
        private HsmProbabilityCalculatorFactory probabilityCalculatorFactory;

        public HsmModelSelector(ISelectionCriterion selectionCriterion) {
            SelectionCriterion = selectionCriterion;
            probabilityCalculatorFactory = new HsmProbabilityCalculatorFactory();
        }
        public IHsmModel Select(List<int> sequence, List<IHsmModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
