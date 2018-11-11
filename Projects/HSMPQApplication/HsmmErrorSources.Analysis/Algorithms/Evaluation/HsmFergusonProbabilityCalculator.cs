using HsmmErrorSources.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsmmErrorSources.Analysis.Algorithms.Evaluation
{
    public class HsmFergusonProbabilityCalculator: AbstractHsmmProbabilityCalculator<HsmmErrorSources.Models.Models.HsmFergusonModel>
    {
        public HsmFergusonProbabilityCalculator(HsmFergusonModel model, List<int> sequence): base (model, sequence) {}
        protected override double CalculateWordProbability(int startIndex, int endIndex, int state, int duration)
        {
            int lastIndex = Sequence.Count - 1;
            if (startIndex < 0 && endIndex <= 0 || startIndex > lastIndex)
            {
                return 1;
            }
            else
            {
                double prod = 1;
                int m = (startIndex >= 0) ? 1 : 1 - startIndex;
                int k = (endIndex <= lastIndex) ? duration : lastIndex - startIndex;

                for (int theta = m; theta <= k; theta++)
                {
                    prod *= Model.B[state, Sequence[startIndex + theta -1]];
                }
                return prod;
            }
        }
    }
}
