using HsmmErrorSources.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsmmErrorSources.Analysis.Algorithms.Evaluation
{
    class HsmQpProbabilityCalculator : AbstractHsmmProbabilityCalculator<HsmQpModel>
    {
        public HsmQpProbabilityCalculator(HsmQpModel model, List<int> sequence) : base(model, sequence)
        {
        }

        protected override double CalculateWordProbability(int startIndex, int endIndex, int state, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
