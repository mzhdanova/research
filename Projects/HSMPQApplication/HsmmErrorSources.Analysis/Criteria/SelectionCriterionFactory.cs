using HsmmErrorSources.Analysis.Criteria;
using System;

namespace HsmmErrorSources.Analysis.Algorithms.Criteria
{
    public class SelectionCriterionFactory
    {
        public ISelectionCriterion CreateSelectionCriterion(SelectionCriterionType criterionType)
        {
            switch (criterionType)
            {
                case SelectionCriterionType.MaximumLikelihood:
                    {
                        return new MaximumLikelihoodSelectionCriterion();
                    }
                case SelectionCriterionType.MaximumMutialInformation:
                    {
                        return new MaximumMutialInformationSelectionCriterion();
                    }
                case SelectionCriterionType.LogMaximumMutialInformation:
                    {
                        return new LogMaxMutialInformationSelectionCriterion();
                    }
                default:
                    {
                        throw new NotImplementedException("SelectionCriterionType is not supported");
                    }
            }
        }
    }
}
