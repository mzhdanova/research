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
    public class SegmentHsmModelSelector : HsmModelSelector
    {
        private int segmentSize = 100;
        public SegmentHsmModelSelector(ISelectionCriterion selectionCriterion, int segmentSize) : base(selectionCriterion){
            this.segmentSize = segmentSize;
        }
        public override IHsmModel Select(List<int> sequence, List<IHsmModel> models)
        {
            IEnumerable<List<int>> segments = splitList(sequence, segmentSize);
            IDictionary<IHsmModel, double> probabilitiesByModels = models.ToDictionary(m => m, m => {
                List<double> probabilities = segments.ToList(s => {
                IProbabilityCalculator probabilityCalculator = probabilityCalculatorFactory.CreateProbabilityCalculator(m, sequence);
                return probabilityCalculator.Calculate();
                })
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