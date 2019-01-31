using System;
using System.Collections.Generic;
using System.Linq;
using HsmmErrorSources.Analysis.Algorithms.Evaluation;
using HsmmErrorSources.Analysis.Criteria;
using HsmmErrorSources.Models.Models;

namespace HsmmErrorSources.Analysis.Algorithms.Selection
{
    public class SegmentHsmModelSelector : HsmModelSelector
    {
        private int segmentSize = 100;
        public SegmentHsmModelSelector(ISelectionCriterion selectionCriterion, int segmentSize) : base(selectionCriterion){
            this.segmentSize = segmentSize;
        }
        public override IHsmModelHolder Select(List<int> sequence, List<IHsmModelHolder> models)
        {
            IEnumerable<List<int>> segments = splitList(sequence, segmentSize);
            IDictionary<IHsmModelHolder, double> probabilitiesByModels = models.ToDictionary(m => m, m => {
                List<double> probabilities = segments.Select(s =>
                {
                    IProbabilityCalculator probabilityCalculator = probabilityCalculatorFactory.CreateProbabilityCalculator(m.Model, s);
                    return probabilityCalculator.Calculate();
                }).ToList();
                return probabilities.Average();
            });
            return selectionCriterion.Apply(probabilitiesByModels);
        }

        public static IEnumerable<List<T>> splitList<T>(List<T> list, int batchSize)
        {
            for (int i = 0; i < list.Count; i += batchSize)
            {
                yield return list.GetRange(i, Math.Min(batchSize, list.Count - i));
            }
        }
    }
}