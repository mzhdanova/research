using HsmmErrorSources.Analysis.Algorithms.Criteria;
using HsmmErrorSources.Analysis.Criteria;
using System;

namespace HsmmErrorSources.Analysis.Algorithms.Selection
{
    public class HsmModelSelectorFactory
    {
        private readonly int _segmentSize;
        private readonly SelectionCriterionFactory _selectionCriterionFactory;
       
        public HsmModelSelectorFactory(int segmentSize) {
            _selectionCriterionFactory = new SelectionCriterionFactory();
            _segmentSize = segmentSize;
        }

        public IModelSelector CreateModelSelector(ModelSelectorType selectorType, SelectionCriterionType criterionType)
        {
            ISelectionCriterion selectionCriterion = _selectionCriterionFactory.CreateSelectionCriterion(criterionType);
            switch (selectorType)
            {
                case ModelSelectorType.Segment:
                    {
                        return new SegmentHsmModelSelector(selectionCriterion, _segmentSize);
                    }
                case ModelSelectorType.Simple:
                    {
                        return new SimpleHsmModelSelector(selectionCriterion);
                    }
                default:
                    {
                        throw new NotImplementedException("ModelSelectorType is not supported");
                    }
            }
        }
    }
}
