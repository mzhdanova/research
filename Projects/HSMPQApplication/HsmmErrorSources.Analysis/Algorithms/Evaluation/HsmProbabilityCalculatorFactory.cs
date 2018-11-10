using HsmmErrorSources.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsmmErrorSources.Analysis.Algorithms.Evaluation
{
    public class HsmProbabilityCalculatorFactory
    {
        public IProbabilityCalculator CreateProbabilityCalculator(IHsmModel model, List<int> sequence)
        {
            switch (model.Type)
            {
                case ModelType.HsmFergusonModel:
                    {
                        return new HsmFergusonProbabilityCalculator((HsmFergusonModel)model, sequence);
                    }
                case ModelType.HsmQpModel:
                    {
                        return new HsmQpProbabilityCalculator((HsmQpModel)model, sequence);
                    }
                default:
                    {
                        throw new NotImplementedException("ModelType is not supported");
                    }
            }
        }
    }
}
